﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcLibrary.Models;

namespace MvcLibrary.Data
{
    public class MvcLibraryContext : DbContext
    {
        public MvcLibraryContext (DbContextOptions<MvcLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<MvcLibrary.Models.Book> Book { get; set; } = default!;

        public DbSet<MvcLibrary.Models.User> User { get; set; }

        public DbSet<MvcLibrary.Models.BookOrder> BookOrder { get; set; }
    }
}
