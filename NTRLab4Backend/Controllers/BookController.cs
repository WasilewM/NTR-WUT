using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTRLab4Backend.Data;
using NTRLab4Backend.Models;
using static System.Reflection.Metadata.BlobBuilder;


namespace NTRLab4Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly NTRLab4BackendContext _context;

        public BookController(NTRLab4BackendContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var Books = from b in _context.Book
                select b;

            Books = Books.Where(b => b.Username == null);
            Books = Books.Where(b => b.ReservedUntil == null);
            Books = Books.Where(b => b.LentUntil == null);

            return new JsonResult(Books);
        }

        [HttpGet("/api/[controller]/myreservations/{Username}")]
        public JsonResult MyReservations(String Username)
        {
            // @TODO: Add validation
            var books = from b in _context.Book
                select b;

            books = books.Where(b => b.Username == Username);
            books = books.Where(b => b.ReservedUntil != null);
            books = books.Where(b => b.LentUntil == null);
            return new JsonResult(books);
        }

        [HttpGet("/api/[controller]/pendingreservations/")]
        public JsonResult PendingReservations()
        {
            // @TODO: Add validation
            var books = from b in _context.Book
                select b;
            
            books = books.Where(b => b.ReservedUntil != null);
            books = books.Where(b => b.LentUntil == null);
            return new JsonResult(books);
        }

        [HttpGet("/api/[controller]/myrentals/{Username}")]
        public JsonResult MyRentals(String Username)
        {
            // @TODO: Add validation
            var books = from b in _context.Book
                select b;

            books = books.Where(b => b.Username == Username);
            books = books.Where(b => b.ReservedUntil == null);
            books = books.Where(b => b.LentUntil != null);
            return new JsonResult(books);
        }

        // @TODO: Fix me if time allows
        // [HttpPost]
        // public async Task<Boolean> Post(Book Book)
        // {
        //     _context.Add(Book);
        //     await _context.SaveChangesAsync();
        //     return true;
        // }

        [HttpPut]
        public async Task<Boolean> Put(Book Book)
        {
            _context.Update(Book);
            await _context.SaveChangesAsync();
            return true;
        }


        [HttpDelete("{id}")]
        public async Task<Boolean> Delete(int id)
        {
            var Book = await _context.Book
                .FirstOrDefaultAsync(b => b.Id == id);

            _context.Book.Remove(Book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
