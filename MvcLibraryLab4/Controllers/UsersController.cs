using System;
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
    }
}
