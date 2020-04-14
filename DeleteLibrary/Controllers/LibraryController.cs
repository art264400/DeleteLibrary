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
    [Authorize]
    public class LibraryController : Controller
    {
        public IlibraryService _libraryService;

        public LibraryController()
        {
            _libraryService = new EnityLibraryService();
        }
        // GET: Library
        public ActionResult ListFreeBooks()
        {
            var freeBooks = _libraryService.GetListFreeBooks();
            return View(freeBooks);
        }

        public ActionResult ReservedBook(int Id)
        {
            var takenBook = new TakenBook
            {
                BookId = Id,
                UserId = _libraryService.GetUserByLogin(User.Identity.Name).Id, //Здесь нужно поставить пользователя, который авторезирован
                IsReserved = true
            };
            _libraryService.RemoveTakenBookByBookId(Id);
           _libraryService.CreateTakenBook(takenBook);
           
            return RedirectToAction("ListFreeBooks");
        }

        public ActionResult ListMyBooks()
        {
            var TakenBooks = _libraryService.GetTakenBooksByUserId(_libraryService.GetUserByLogin(User.Identity.Name).Id);
            return View(TakenBooks);
        }
        public ActionResult ListReservedMyBooks()
        {
            var reservedTakenBooks = _libraryService.GetReservedTakenBooksByUserId(_libraryService.GetUserByLogin(User.Identity.Name).Id);
            return View(reservedTakenBooks);
        }

        public ActionResult ListAllBooks()
        {
            var takenBooks = _libraryService.GetAllTakenBooks();
            return View(takenBooks);
        }

    }
}