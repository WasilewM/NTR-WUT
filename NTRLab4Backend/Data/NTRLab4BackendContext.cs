using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NTRLab4Backend.Models;

namespace NTRLab4Backend.Data
{
    public class NTRLab4BackendContext : DbContext
    {
        public NTRLab4BackendContext (DbContextOptions<NTRLab4BackendContext> options)
            : base(options)
        {
        }

        public DbSet<NTRLab4Backend.Models.Book> Book { get; set; } = default!;

        public DbSet<NTRLab4Backend.Models.User> User { get; set; }
    }
}
