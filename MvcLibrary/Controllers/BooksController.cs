using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using MvcLibrary.Data;
using MvcLibrary.Models;
using NuGet.Packaging.Signing;

namespace MvcLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly MvcLibraryContext _context;

        public BooksController(MvcLibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(b => b.Genre == bookGenre);
            }

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        { 
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        private bool BookExists(int id)
        {
          return _context.Book.Any(e => e.Id == id);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserve(int? id, byte[] timeStamp)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (HttpContext.Session.GetInt32(SessionData.SessionKeyIsLibrarian) == 1)
            {
                return RedirectToAction("ErrorLibrarianBookReservation");
            }

            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            try
            {
                // This should be uncommented to prevent the same user from re-reserving the same book 
                // the same day.
                // It has been commented out in order to allow the user to check the concurrency.
                // if (book.ReservedUntil == null && book.LentUntil == null)
                // {
                    book.UserId = HttpContext.Session.GetInt32(SessionData.SessionKeyUserId);
                    book.ReservedUntil = DateTime.Today.AddDays(1);
                    book.LentUntil = null;
                    // book.TimeStamp = DateTime.Now;
                    _context.Entry(book).Property("TimeStamp").OriginalValue = timeStamp;
                    _context.Update(book);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Success", "Home");
                // }
                //
                // return RedirectToAction("ErrorBookUnavailable");
                
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("ErrorBookUnavailable");
            }
        }

        public async Task<IActionResult> BookReservations()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (HttpContext.Session.GetInt32(SessionData.SessionKeyIsLibrarian) == 0)
            {
                return RedirectToAction("BookReservationsUser");
            }

            return RedirectToAction("BookReservationsLibrarian");
        }

        public async Task<IActionResult> BookReservationsUser(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            books = books.Where(s => s.UserId == HttpContext.Session.GetInt32(SessionData.SessionKeyUserId) && s.ReservedUntil != null && s.LentUntil == null);

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(b => b.Genre == bookGenre);
            }

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
        }

        public async Task<IActionResult> CancelReservation(int? id, byte[] timeStamp)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            try
            {
                // This should be uncommented to prevent from modifying a book in an invalid state
                // It has been commented out in order to allow the user to check the concurrency.
                // if (book.ReservedUntil != null && book.LentUntil == null)
                // {
                    book.UserId = null;
                    book.ReservedUntil = null;
                    book.LentUntil = null;
                    _context.Entry(book).Property("TimeStamp").OriginalValue = timeStamp;
                    _context.Update(book);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Success", "Home");
                // }
                // return RedirectToAction("ErrorSomethingWentWrong");
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("ErrorSomethingWentWrong");
            }
        }

        public async Task<IActionResult> BookReservationsLibrarian(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            books = books.Where(s => s.UserId != null && s.ReservedUntil != null && s.LentUntil == null);


            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(b => b.Genre == bookGenre);
            }

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
        }

        public async Task<IActionResult> Lend(int? id, byte[] timeStamp)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (HttpContext.Session.GetInt32(SessionData.SessionKeyIsLibrarian) == 0)
            {
                return RedirectToAction("ErrorNotLibrarianLend");
            }

            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            try
            {
                // This should be uncommented to prevent the the rental of a book in an invalid state
                // It has been commented out in order to allow the user to check the concurrency.
                // if (book.ReservedUntil != null && book.LentUntil == null)
                // {
                    book.ReservedUntil = null;
                    book.LentUntil = DateTime.Today.AddDays(30);
                    _context.Entry(book).Property("TimeStamp").OriginalValue = timeStamp;
                    _context.Update(book);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Success", "Home");
                // }
                // return RedirectToAction("ErrorSomethingWentWrong");
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("ErrorSomethingWentWrong");
            }

        }

        public async Task<IActionResult> BookRentals()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (HttpContext.Session.GetInt32(SessionData.SessionKeyIsLibrarian) == 0)
            {
                return RedirectToAction("BookRentalsUser");
            }

            return RedirectToAction("BookRentalsLibrarian");
        }

        public async Task<IActionResult> BookRentalsUser(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            books = books.Where(s => s.UserId == HttpContext.Session.GetInt32(SessionData.SessionKeyUserId) && s.ReservedUntil == null && s.LentUntil != null);

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(b => b.Genre == bookGenre);
            }

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
        }

        public async Task<IActionResult> BookRentalsLibrarian(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            books = books.Where(s => s.UserId != null && s.ReservedUntil == null && s.LentUntil != null);

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(b => b.Genre == bookGenre);
            }

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
        }

        public async Task<IActionResult> AcceptReturn(int? id, byte[] timeStamp)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (HttpContext.Session.GetInt32(SessionData.SessionKeyIsLibrarian) == 0)
            {
                return RedirectToAction("ErrorNotLibrarianAcceptReturn");
            }

            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }


            try
            {
                // This should be uncommented to prevent the same user from accepting return of a book in an invalid state
                // It has been commented out in order to allow the user to check the concurrency.
                // if (book.ReservedUntil == null && book.LentUntil != null)
                // {
                    book.UserId = null;
                    book.ReservedUntil = null;
                    book.LentUntil = null;
                    _context.Entry(book).Property("TimeStamp").OriginalValue = timeStamp;
                    _context.Update(book);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Success", "Home");
                // }
                //
                // return RedirectToAction("ErrorSomethingWentWrong");
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("ErrorBookUnavailable");
            }
        }

        // Messages
        public IActionResult ErrorLibrarianBookReservation()
        {
            Message info = new Message("Error", "Cannot reserve the book", 
                "Librarian cannot reserve books.");
            return View("Message", info);
        }
        public IActionResult ErrorBookUnavailable()
        {
            Message info = new Message("Error", "Cannot reserve the book", 
                "Chosen book has already been reserved or rented by you or by some other user.");
            return View("Message", info);
        }

        public IActionResult ErrorSomethingWentWrong()
        {
            Message info = new Message("Error", "Cannot proceed chosen action", 
                "Something went wrong");
            return View("Message", info);
        }

        public IActionResult ErrorNotLibrarianLend()
        {
            Message info = new Message("Error", "Cannot lend the book", 
                "Only Librarian can lend a book to a User.");
            return View("Message", info);
        }

        public IActionResult ErrorNotLibrarianAcceptReturn()
        {
            Message info = new Message("Error", "Cannot lend the book", 
                "Only Librarian can accept a return of a book.");
            return View("Message", info);
        }
    }

}
