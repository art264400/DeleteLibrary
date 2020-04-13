using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeleteLibrary.Interfaces;
using DeleteLibrary.Models;
using DeleteLibrary.Services;

namespace DeleteLibrary.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IlibraryService _libraryService;

        public AdminController()
        {
            _libraryService=new EnityLibraryService();
        }

        public ActionResult Index()
        {
            var books= _libraryService.GetAllBooks();
            return View(books);
        }

        public ActionResult RemoveBook(int id)
        {
            _libraryService.RemoveBookById(id);
            _libraryService.RemoveTakenBookByBookId(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditBook(int id)
        {
            var book = _libraryService.GetBookById(id);
            if (book == null) return HttpNotFound();

            return View(book);
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {

            _libraryService.UpdateBook(book);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateBook()
        {
            var book = new Book();
            return View(book);
        }
        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            _libraryService.CreateBook(book);
            return RedirectToAction("Index");
        }

        public ActionResult ListTakenBooks()
        {
            var takenBooks = _libraryService.GetAllTakenBooks();
            return View(takenBooks);
        }

        public ActionResult ReturnBook(int Id)
        {
            _libraryService.ReturnTakenBookById(Id);
            return RedirectToAction("ListTakenBooks");
        }
        public ActionResult RemoveReservedAtTakenBook(int Id)
        {
            _libraryService.RemoveReservedAtTakenBookById(Id);
            return RedirectToAction("ListTakenBooks");
        }
        public ActionResult ListUsers()
        {
            var users = _libraryService.GetAllUsers();
            return View(users);
        }
        public ActionResult RemoveUser(int Id)
        {
            _libraryService.RemoveUserById(Id);
            return RedirectToAction("ListUsers");
        }
        [HttpGet]
        public ActionResult EditUser(int Id)
        {
            var user = _libraryService.GetUserById(Id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {

            _libraryService.UpdateUser(user);
            return RedirectToAction("ListUsers");
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            var user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            _libraryService.CreateUser(user);
            return RedirectToAction("ListUsers");
        }
    }
}