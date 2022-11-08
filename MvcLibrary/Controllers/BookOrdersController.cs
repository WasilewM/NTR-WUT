using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcLibrary.Data;
using MvcLibrary.Models;

namespace MvcLibrary.Controllers
{
    public class BookOrdersController : Controller
    {
        private readonly MvcLibraryContext _context;

        public BookOrdersController(MvcLibraryContext context)
        {
            _context = context;
        }

        // GET: BookOrders
        public async Task<IActionResult> Index()
        {
              return View(await _context.BookOrder.ToListAsync());
        }

        // GET: BookOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookOrder == null)
            {
                return NotFound();
            }

            var bookOrder = await _context.BookOrder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookOrder == null)
            {
                return NotFound();
            }

            return View(bookOrder);
        }

        // GET: BookOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,BookId,BookOrderStatus")] BookOrder bookOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookOrder);
        }

        // GET: BookOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookOrder == null)
            {
                return NotFound();
            }

            var bookOrder = await _context.BookOrder.FindAsync(id);
            if (bookOrder == null)
            {
                return NotFound();
            }
            return View(bookOrder);
        }

        // POST: BookOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BookId,BookOrderStatus")] BookOrder bookOrder)
        {
            if (id != bookOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookOrderExists(bookOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookOrder);
        }

        // GET: BookOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookOrder == null)
            {
                return NotFound();
            }

            var bookOrder = await _context.BookOrder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookOrder == null)
            {
                return NotFound();
            }

            return View(bookOrder);
        }

        // POST: BookOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookOrder == null)
            {
                return Problem("Entity set 'MvcLibraryContext.BookOrder'  is null.");
            }
            var bookOrder = await _context.BookOrder.FindAsync(id);
            if (bookOrder != null)
            {
                _context.BookOrder.Remove(bookOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookOrderExists(int id)
        {
          return _context.BookOrder.Any(e => e.Id == id);
        }
    }
}
