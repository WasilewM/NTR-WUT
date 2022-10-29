using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcLibrary.Data;
using System;
using System.Linq;

namespace MvcLibrary.Models
{
    public class SeedData
    {
        public static void Initialiaze(IServiceProvider serviceProvider)
        {
            using (var context = new MvcLibraryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcLibraryContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return; // DB has been seeded
                }

                context.Book.AddRange(
                new Book
                {
                    Title = "The Witcher Sword of Destiny",
                    ReleaseDate = DateTime.Parse("1992-01-01"),
                    Genre = "Fantasy",
                    Price = 29
                },

                new Book
                {
                    Title = "The Witcher The Last Wish",
                    ReleaseDate = DateTime.Parse("1993-01-01"),
                    Genre = "Fantasy",
                    Price = 39
                },

                new Book
                {
                    Title = "The Witcher Blood of Elves",
                    ReleaseDate = DateTime.Parse("1994-01-01"),
                    Genre = "Fantasy",
                    Price = 34,
                }
            );
                context.SaveChanges();
            }
        }
    }
}
