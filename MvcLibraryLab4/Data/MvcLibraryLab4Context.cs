using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcLibraryLab4.Models;

namespace MvcLibraryLab4.Data
{
    public class MvcLibraryLab4Context : DbContext
    {
        public MvcLibraryLab4Context (DbContextOptions<MvcLibraryLab4Context> options)
            : base(options)
        {
        }
        
        public DbSet<MvcLibraryLab4.Models.Book> Book { get; set; } = default!;
    }
}
