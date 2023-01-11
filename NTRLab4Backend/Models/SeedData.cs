﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NTRLab4Backend.Data;
using System;
using System.Linq;

namespace NTRLab4Backend.Models
{
    public class SeedData
    {
        public static void Initialiaze(IServiceProvider serviceProvider)
        {
            using (var context = new NTRLab4BackendContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NTRLab4BackendContext>>()))
            {
                // Look for any Users.
                if (!context.User.Any())
                {
                    context.User.AddRange(
                        // Add Librarian
                        new User
                        {
                            Username = "Librarian",
                            FirstName = "Henryk",
                            LastName = "Sienkiewicz",
                            Password = "admin123",
                            IsLibrarian = 1
                        },
                        new User
                        {
                            Username = "sbatory",
                            FirstName = "Stefan",
                            LastName = "Batory",
                            Password = "123456789",
                            IsLibrarian = 0
                        },
                        new User
                        {
                            Username = "szolkiew",
                            FirstName = "Stanisław",
                            LastName = "Żółkiewski",
                            Password = "123456789",
                            IsLibrarian = 0
                        }
                    );
                }

                // Look for any Books.
                if (!context.Book.Any())
                {
                    context.Book.AddRange(
                        // Genre: Fantasy
                        // The Wither Saga
                        new Book
                        {
                            Title = "The Witcher Sword of Destiny",
                            Author = "Andrzej Sapkowski",
                            ReleaseDate = DateTime.Parse("1992-01-01"),
                            Genre = "Fantasy",
                            PagesNumber = 384,
                            
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
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        // The Chronicles of Narnia Saga
                        new Book
                        {
                            Title = "The Chronicles of Narnia The Lion, The With and The Wardrobe",
                            Author = "C. S. Levis",
                            ReleaseDate = DateTime.Parse("1950-10-16"),
                            Genre = "Fantasy",
                            PagesNumber = 200,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        new Book
                        {
                            Title = "The Chronicles of Narnia Prince Caspian",
                            Author = "C. S. Levis",
                            ReleaseDate = DateTime.Parse("1951-10-15"),
                            Genre = "Fantasy",
                            PagesNumber = 195,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        new Book
                        {
                            Title = "The Chronicles of Narnia The Voyage of The Dawn Treader",
                            Author = "C. S. Levis",
                            ReleaseDate = DateTime.Parse("1952-09-15"),
                            Genre = "Fantasy",
                            PagesNumber = 223,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        new Book
                        {
                            Title = "The Chronicles of Narnia The Lion, The Silver Chair",
                            Author = "C. S. Levis",
                            ReleaseDate = DateTime.Parse("1953-09-07"),
                            Genre = "Fantasy",
                            PagesNumber = 217,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        new Book
                        {
                            Title = "The Chronicles of Narnia The Horse and His Boy",
                            Author = "C. S. Levis",
                            ReleaseDate = DateTime.Parse("1954-09-06"),
                            Genre = "Fantasy",
                            PagesNumber = 199,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        new Book
                        {
                            Title = "The Chronicles of Narnia The Magician's Nephew",
                            Author = "C. S. Levis",
                            ReleaseDate = DateTime.Parse("1955-05-02"),
                            Genre = "Fantasy",
                            PagesNumber = 183,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        new Book
                        {
                            Title = "The Chronicles of Narnia The Last Battle",
                            Author = "C. S. Levis",
                            ReleaseDate = DateTime.Parse("1956-09-04"),
                            Genre = "Fantasy",
                            PagesNumber = 184,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        // Genre: Education
                        new Book
                        {
                            Title = "Clean Code",
                            Author = "Robert C. Martin",
                            ReleaseDate = DateTime.Parse("2009-03-01"),
                            Genre = "Education",
                            PagesNumber = 464,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        },

                        new Book
                        {
                            Title = "Clean Architecture",
                            Author = "Robert C. Martin",
                            ReleaseDate = DateTime.Parse("2017-09-01"),
                            Genre = "Education",
                            PagesNumber = 432,
                            
                            ReservedUntil = null,
                            LentUntil = null
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
