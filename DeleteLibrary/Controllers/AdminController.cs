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
    }
}