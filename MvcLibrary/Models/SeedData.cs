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
                    Author = "Andrzej Sapkowski",
                    ReleaseDate = DateTime.Parse("1992-01-01"),
                    Genre = "Fantasy",
                    PagesNumber = 384,
                    UserId = null,
                    ReservedUntil = null,
                    LentUntil = null
                },

                new Book
                {
                    Title = "The Witcher The Last Wish",
                    Author = "Andrzej Sapkowski",
                    ReleaseDate = DateTime.Parse("1993-01-01"),
                    Genre = "Fantasy",
                    PagesNumber = 288,
                    UserId = null,
                    ReservedUntil = null,
                    LentUntil = null
                },

                new Book
                {
                    Title = "The Witcher Blood of Elves",
                    Author = "Andrzej Sapkowski",
                    ReleaseDate = DateTime.Parse("1994-01-01"),
                    Genre = "Fantasy",
                    PagesNumber = 320,
                    UserId = null,
                    ReservedUntil = null,
                    LentUntil = null
                },

                new Book
                {
                    Title = "The Witcher Time of Contempt",
                    Author = "Andrzej Sapkowski",
                    ReleaseDate = DateTime.Parse("1995-01-01"),
                    Genre = "Fantasy",
                    PagesNumber = 351,
                    UserId = null,
                    ReservedUntil = null,
                    LentUntil = null
                },

                new Book
                {
                    Title = "The Witcher Baptism of Fire",
                    Author = "Andrzej Sapkowski",
                    ReleaseDate = DateTime.Parse("1996-01-01"),
                    Genre = "Fantasy",
                    PagesNumber = 352,
                    UserId = null,
                    ReservedUntil = null,
                    LentUntil = null
                },

                new Book
                {
                    Title = "The Witcher The Tower of the Swallow",
                    Author = "Andrzej Sapkowski",
                    ReleaseDate = DateTime.Parse("1997-01-01"),
                    Genre = "Fantasy",
                    PagesNumber = 464,
                    UserId = null,
                    ReservedUntil = null,
                    LentUntil = null
                },

                new Book
                {
                    Title = "The Witcher The Lady of the Lake",
                    Author = "Andrzej Sapkowski",
                    ReleaseDate = DateTime.Parse("1999-01-01"),
                    Genre = "Fantasy",
                    PagesNumber = 544,
                    UserId = null,
                    ReservedUntil = null,
                    LentUntil = null
                },

                new Book
                {
                    Title = "The Witcher Season of Storms",
                    Author = "Andrzej Sapkowski",
                    ReleaseDate = DateTime.Parse("2013-01-01"),
                    Genre = "Fantasy",
                    PagesNumber = 384,
                    UserId = null,
                    ReservedUntil = null,
                    LentUntil = null
                }

                );
                context.SaveChanges();
            }
        }
    }
}
