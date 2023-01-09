using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcLibraryLab4.Data;
using MvcLibraryLab4.Models;

namespace MvcLibraryLab4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly MvcLibraryLab4Context _context;

        public BooksController(MvcLibraryLab4Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            var books = from b in _context.Book
                select b;
            return books.ToArray();

        }
    }

}
