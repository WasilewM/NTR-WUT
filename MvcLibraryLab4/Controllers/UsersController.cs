﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MvcLibraryLab4.Data;
using MvcLibraryLab4.Models;

namespace MvcLibraryLab4.Controllers
{
    public class UsersController : Controller
    {
        private readonly MvcLibraryLab4Context _context;

        public UsersController(MvcLibraryLab4Context context)
        {
            _context = context;
        }

        // // GET: Users/Create
        // public IActionResult Create()
        // {
        //     return View();
        // }
        //
        // // POST: Users/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Username,FirstName,LastName,Password,IsLibrarian,TimeStamp")] User user)
        // {
        //     var potential_conflict_user = await _context.User
        //         .FirstOrDefaultAsync(m => m.Username == user.Username);
        //     if (potential_conflict_user != null)
        //     {
        //         return RedirectToAction("ErrorUsernameOccupied");
        //     }
        //
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(user);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction("LogIn");
        //     }
        //     return View(user);
        // }
        //
        // // GET: Users/Delete
        // public async Task<IActionResult> Delete()
        // {
        //     int? id = HttpContext.Session.GetInt32(SessionData.SessionKeyUserId);
        //     if (id == null || _context.User == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var user = await _context.User
        //         .FirstOrDefaultAsync(m => m.Id == id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     if (user.IsLibrarian == 1)
        //     {
        //         return RedirectToAction("ErrorDeleteLibrarianAccount");
        //     }
        //
        //     var books = from b in _context.Book
        //         select b;
        //
        //     books = books.Where(s => s.UserId == HttpContext.Session.GetInt32(SessionData.SessionKeyUserId));
        //
        //     var Books = await books.ToListAsync();
        //     if (Books.Count == 0)
        //     {
        //         return View(user);
        //     }
        //
        //     return RedirectToAction("ErrorDeleteUserAccountWithBooks");
        // }
        //
        // // POST: Users/Delete
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed()
        // {
        //     int? id = HttpContext.Session.GetInt32(SessionData.SessionKeyUserId);
        //     if (_context.User == null)
        //     {
        //         return Problem("Entity set 'MvcLibraryContext.User' is null.");
        //     }
        //     var user = await _context.User.FindAsync(id);
        //     if (user != null)
        //     {
        //         _context.User.Remove(user);
        //     }
        //
        //     await _context.SaveChangesAsync();
        //     HttpContext.Session.Remove(SessionData.SessionKeyUserId);
        //     return RedirectToAction("Index", controllerName:"Home");
        // }
        //
        // private bool UserExists(int id)
        // {
        //   return _context.User.Any(e => e.Id == id);
        // }
        //
        // // GET: Users/Create
        // public IActionResult LogIn()
        // {
        //     return View();
        // }
        //
        // // POST: Users/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> LogIn(string Username, string Password)
        // {
        //     var person = await _context.User
        //         .FirstOrDefaultAsync(p => p.Username == Username);
        //
        //     if (person == null || Password != person.Password)
        //     {
        //         return RedirectToAction("ErrorInvalidCredentials");
        //     }
        //     
        //     HttpContext.Session.SetInt32(SessionData.SessionKeyUserId, person.Id);
        //     HttpContext.Session.SetInt32(SessionData.SessionKeyIsLibrarian, person.IsLibrarian);
        //     return RedirectToAction("MyAccount");
        // }
        //
        // public async Task<IActionResult> MyAccount()
        // {
        //     if (!IsUserLoggedIn())
        //     {
        //         return RedirectToAction("PleaseLogIn", "Home");
        //     }
        //
        //     var user = await _context.User
        //         .FirstOrDefaultAsync(m => m.Id == HttpContext.Session.GetInt32(SessionData.SessionKeyUserId));
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return View(user);
        // }
        //
        // public async Task<IActionResult> LogOut()
        // {
        //     HttpContext.Session.Remove(SessionData.SessionKeyUserId);
        //     HttpContext.Session.Remove(SessionData.SessionKeyIsLibrarian);
        //     return RedirectToAction("LogIn");
        // }
        //
        // public bool IsUserLoggedIn()
        // {
        //     if (string.IsNullOrWhiteSpace(HttpContext.Session.GetInt32(SessionData.SessionKeyUserId).ToString()))
        //     {
        //         return false;
        //     }
        //
        //     return true;
        // }
        //
        // // Messages
        // public IActionResult ErrorUsernameOccupied()
        // {
        //     Message info = new Message("Error", "Cannot create an account", 
        //         "Chosen username is occupied.");
        //     return View("Message", info);
        // }
        // public IActionResult ErrorDeleteLibrarianAccount()
        // {
        //     Message info = new Message("Error", "Cannot delete your account", 
        //         "Librarian account cannot be deleted.");
        //     return View("Message", info);
        // }
        // public IActionResult ErrorDeleteUserAccountWithBooks()
        // {
        //     Message info = new Message("Error", "Cannot delete your account", 
        //         "You cannot delete your account until you return all your books and cancel all book reservations.");
        //     return View("Message", info);
        // }
        //
        // public IActionResult ErrorInvalidCredentials()
        // {
        //     Message info = new Message("Error", "Invalid Credentials", 
        //         "Invalid username or password. Please try again.");
        //     return View("Message", info);
        // }
    }
}
