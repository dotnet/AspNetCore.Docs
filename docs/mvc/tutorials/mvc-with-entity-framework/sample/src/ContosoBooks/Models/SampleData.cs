using Microsoft.Data.Entity.SqlServer;
using System;
using System.Threading.Tasks;
using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;

namespace ContosoBooks.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = serviceProvider.GetService<BookContext>())
            {
                var sqlServerDb = db.Database as SqlServerDatabase;
                if (sqlServerDb != null)
                {
                    sqlServerDb.EnsureDeleted();

                    if (sqlServerDb.EnsureCreated())
                    {
                        InsertTestData(db);
                    }
                }
                else
                {
                    InsertTestData(db);
                }
            }
        }

        private static void InsertTestData(BookContext db)
        {
            var authors = new Author[]
            {
                    new Author() { LastName = "Austen", FirstMidName = "Jane" },
                    new Author() { LastName = "Dickens", FirstMidName = "Charles" },
                    new Author() { LastName = "Cervantes", FirstMidName = "Miguel" }
            };

            foreach (var item in authors)
            {
                if (!db.Authors.Any(x => x.LastName.Equals(item.LastName)))
                {
                    db.Authors.Add(item);
                }
            }
            db.SaveChanges();

            var books = new Book[]
            {
                new Book() { Title = "Pride and Prejudice", Year = 1813, AuthorID = authors[0].AuthorID,
                            Price = 9.99M, Genre = "Comedy of manners" },
                new Book() { Title = "Northanger Abbey", Year = 1817, AuthorID = authors[0].AuthorID,
                    Price = 12.95M, Genre = "Gothic parody" },
                new Book() { Title = "David Copperfield", Year = 1850, AuthorID = authors[1].AuthorID,
                    Price = 15, Genre = "Bildungsroman" },
                new Book() { Title = "Don Quixote", Year = 1617, AuthorID = authors[2].AuthorID,
                    Price = 8.95M, Genre = "Picaresque" }
                };

            foreach (var item in books)
            {
                if (!db.Books.Any(x => x.Title.Equals(item.Title)))
                {
                    db.Books.Add(item);
                }
            }
            db.SaveChanges();
        }
    }
}
