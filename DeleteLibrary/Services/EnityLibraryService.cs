using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using DeleteLibrary.Context;
using DeleteLibrary.Interfaces;
using DeleteLibrary.Models;

namespace DeleteLibrary.Services
{
    public class EnityLibraryService : IlibraryService
    {
        public Book[] GetAllBooks()
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.Books.Where(m => m.IsDeleted == false).ToArray();
            }
        }

        public Book GetBookById(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.Books.FirstOrDefault(m => m.Id == id);
            }

        }

        public bool CreateBook(Book newBook)
        {
            using (LibraryContext db = new LibraryContext())
            {
                try
                {
                    db.Books.AddOrUpdate(newBook);
                    return true;
                }
                catch 
                {
                    return false;
                }

            }

        }

        public bool RemoveBookById(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                try
                {
                    var book = GetBookById(id);
                    if (book == null) return false;
                    book.IsDeleted = true;
                    db.Books.AddOrUpdate(book);
                    db.SaveChanges();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }
        }

        public bool UpdateBook(Book updateBook)
        {
            using (LibraryContext db = new LibraryContext())
            {
                try
                {
                    db.Books.AddOrUpdate(updateBook);
                    db.SaveChanges();
                    return true;
                }
                catch 
                {
                    return false;
                }
              
            }
        }
    }
}