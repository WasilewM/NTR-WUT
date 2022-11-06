using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcLibrary.Data;
using MvcLibrary.Models;

namespace MvcLibrary.Controllers
{
    public class UsersController : Controller
    {
        private readonly MvcLibraryContext _context;

        public UsersController(MvcLibraryContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            // if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            //     return RedirectToAction("Details", HttpContext.Session.GetInt32(SessionData.SessionKeyUserId));
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,FirstName,LastName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
          return _context.User.Any(e => e.Id == id);
        }

        // GET: Users/Create
        public IActionResult LogIn()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(string Username, string Password)
        {
            var person = await _context.User
                .FirstOrDefaultAsync(p => p.Username == Username);

            if (person == null || Password != person.Password)
            {
                return RedirectToAction("InvalidCredentials");
            }
            else
            {
                HttpContext.Session.SetInt32(SessionData.SessionKeyUserId, person.Id);
                return RedirectToAction("MyDashboard");
            }
        }

        public IActionResult InvalidCredentials()
        {
            return View();
        }

        public async Task<IActionResult> MyDashboard()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == HttpContext.Session.GetInt32(SessionData.SessionKeyUserId));
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}
