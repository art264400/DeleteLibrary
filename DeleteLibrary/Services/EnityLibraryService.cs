using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                db.Books.Add(newBook);
                db.SaveChanges();
            }
            var takenBook = new TakenBook
            {
                BookId = newBook.Id,
                DateTake = DateTime.Now,
                IsReserved = false,
                UserId = 1
            };
            CreateTakenBook(takenBook);
            return true;
        }

        public bool RemoveBookById(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                var book = GetBookById(id);
                if (book == null) return false;
                book.IsDeleted = true;
                db.Books.AddOrUpdate(book);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateBook(Book updateBook)
        {
            using (LibraryContext db = new LibraryContext())
            {
                db.Books.AddOrUpdate(updateBook);
                db.SaveChanges();
                return true;
            }
        }


        public User[] GetAllUsers()
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.Users.Where(m => m.IsDeleted == false).Include(m=>m.Role).ToArray();
            }
        }

        public User GetUserById(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.Users.Include(m=>m.Role).FirstOrDefault(m => m.Id == id);
            }
        }
        public User GetUserByLogin(string login)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.Users.Include(m => m.Role).FirstOrDefault(m => m.Login == login);
            }
        }

        public bool CreateUser(User newUser)
        {
            using (LibraryContext db = new LibraryContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return true;
            }
        }

        public bool RemoveUserById(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                var user = GetUserById(id);
                if (user == null) return false;
                user.IsDeleted = true;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateUser(User updateUser)
        {
            using (LibraryContext db = new LibraryContext())
            {
                db.Users.AddOrUpdate(updateUser);
                db.SaveChanges();
                return true;
            }
        }

        public bool CreateTakenBook(TakenBook newTakenBook)
        {
            using (LibraryContext db = new LibraryContext())
            {
                db.TakenBooks.Add(newTakenBook);
                db.SaveChanges(); 
                return true;
            }
        }

        public TakenBook[] GetAllTakenBooks()
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.TakenBooks.Where(m => m.IsDeleted == false).Include(m=>m.Book).Include(m=>m.User).ToArray();
            }
        }
        public TakenBook[] GetAllOnDeletedTakenBooks()
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.TakenBooks.Include(m => m.Book).Include(m => m.User).ToArray();
            }
        }
        public TakenBook[] GetTakenBooksByUserId(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return GetAllTakenBooks().Where(m => m.IsReserved == false && m.User.Id == id).ToArray();
            }
        }
        public TakenBook[] GetReservedTakenBooksByUserId(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return GetAllTakenBooks().Where(m => m.IsReserved == true && m.User.Id == id).ToArray();
            }
        }

        public TakenBook GetTakenBookById(int id)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.TakenBooks.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool ReturnTakenBookById(int id)
        {
            var takenBook = GetTakenBookById(id);
            takenBook.DateReturn=DateTime.Now;
            takenBook.IsDeleted = true;
            UpdateTakenBook(takenBook);
            var newTakenBook = new TakenBook
            {
                BookId = takenBook.BookId,
                DateTake = DateTime.Now,
                UserId = 1
            };
            CreateTakenBook(newTakenBook);
            return true;
        }
        public bool UpdateTakenBook(TakenBook updateTakenBook)
        {
            using (LibraryContext db = new LibraryContext())
            {
                db.TakenBooks.AddOrUpdate(updateTakenBook);
                db.SaveChanges();
                return true;
            }
        }

        public bool RemoveReservedAtTakenBookById(int id)
        {
            var takenBook = GetTakenBookById(id);
            takenBook.DateTake=DateTime.Now;
            takenBook.IsReserved = false;
            UpdateTakenBook(takenBook);
            return true;
        }

        public TakenBook GetTakenBookByBookId(int bookId)
        {
            using (LibraryContext db = new LibraryContext())
            {
                return db.TakenBooks.Where(m=>m.IsDeleted==false).FirstOrDefault(m => m.BookId == bookId);
            }
        }

        public bool RemoveTakenBookByBookId(int bookId)
        {
            using (LibraryContext db = new LibraryContext())
            {
                var takenBook = GetTakenBookByBookId(bookId);
                if (takenBook == null) return false;
                takenBook.IsDeleted = true;
                db.TakenBooks.AddOrUpdate(takenBook);
                db.SaveChanges();
                return true;
            }
        }

        public Book[] GetListFreeBooks()
        {
            var TakenBooks = GetAllTakenBooks();
            var Books = TakenBooks.Where(m => m.UserId == 1).Where(m=>m.IsReserved==false).Select(m => m.Book);
            return Books.ToArray();
        }

        public User GetUserByLoginModel(LoginModel loginModel)
        {
            using (LibraryContext db =new LibraryContext())
            {
                return db.Users.Where(m => m.IsDeleted == false)
                    .FirstOrDefault(m => m.Login == loginModel.Login && m.Password == loginModel.Password);
            }
        }

       
    }
}