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
                return RedirectToAction("PleaseLogIn");
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

            switch (book.Status)
            {
                case (int)BookStatusEnum.Available:
                    book.Status = (int)BookStatusEnum.Unavailable;
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ReservationConfirmation");
                
                case (int)BookStatusEnum.Unavailable:
                    return RedirectToAction("ReservationBookUnavailable");
                
                default:
                    return NotFound();
        }
        }

        public IActionResult PleaseLogIn()
        {
            return View();
        }

        public IActionResult ReservationConfirmation()
        {
            return View();
        }
        
        public IActionResult ReservationBookUnavailable()
        {
            return View();
        }

    }

}
