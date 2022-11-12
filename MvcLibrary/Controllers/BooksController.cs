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

        // GET: Books/Reserve/5
        public async Task<IActionResult> Reserve(int? id)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (HttpContext.Session.GetInt32(SessionData.SessionKeyIsLibrarian) == 1)
            {
                return RedirectToAction("Failure", "Home");
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

            if (book.ReservedUntil == null && book.LentUntil == null)
            {
                book.UserId = HttpContext.Session.GetInt32(SessionData.SessionKeyUserId);
                book.ReservedUntil = DateTime.Today.AddDays(1);
                book.LentUntil = null;
                _context.Update(book);
                await _context.SaveChangesAsync();

                return RedirectToAction("Success", "Home");
            }
            
            return RedirectToAction("Failure", "Home");
        }

        public async Task<IActionResult> CancelReservation(int? id)
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

            if (book.ReservedUntil != null && book.LentUntil == null)
            {
                book.UserId = null;
                book.ReservedUntil = null;
                book.LentUntil = null;
                _context.Update(book);
                await _context.SaveChangesAsync();

                return RedirectToAction("Success", "Home");
            }

            return RedirectToAction("Failure", "Home");
        }

        public async Task<IActionResult> BookReservations()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (HttpContext.Session.GetInt32(SessionData.SessionKeyIsLibrarian) == 0)
            {
                return RedirectToAction("BooksReservedByUser");
            }

            return RedirectToAction("BookReservationsLibrarian");
        }

        public async Task<IActionResult> BooksReservedByUser()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            books = books.Where(s => s.UserId == HttpContext.Session.GetInt32(SessionData.SessionKeyUserId) && s.ReservedUntil != null && s.LentUntil == null);

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
        }

        public async Task<IActionResult> BookReservationsLibrarian()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            books = books.Where(s => s.UserId != null && s.ReservedUntil != null && s.LentUntil == null);

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
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

        public async Task<IActionResult> BookRentalsUser()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            books = books.Where(s => s.UserId == HttpContext.Session.GetInt32(SessionData.SessionKeyUserId) && s.ReservedUntil == null && s.LentUntil != null);

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
        }

        public async Task<IActionResult> BookRentalsLibrarian()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                orderby b.Genre
                select b.Genre;

            var books = from b in _context.Book
                select b;

            books = books.Where(s => s.UserId != null && s.ReservedUntil == null && s.LentUntil != null);

            var bookGenreVM = new BookGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Books = await books.ToListAsync()
            };

            return View(bookGenreVM);
        }

        public async Task<IActionResult> Lend(int? id)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return RedirectToAction("PleaseLogIn", "Home");
            }

            if (HttpContext.Session.GetInt32(SessionData.SessionKeyIsLibrarian) == 0)
            {
                return RedirectToAction("Failure", "Home");
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

            if (book.ReservedUntil != null && book.LentUntil == null)
            {
                book.ReservedUntil = null;
                book.LentUntil = DateTime.Today.AddDays(1); ;
                _context.Update(book);
                await _context.SaveChangesAsync();

                return RedirectToAction("Success", "Home");
            }

            return RedirectToAction("Failure", "Home");
        }
    }

}
