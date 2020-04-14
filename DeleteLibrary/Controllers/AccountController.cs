using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DeleteLibrary.Interfaces;
using DeleteLibrary.Models;
using DeleteLibrary.Services;

namespace DeleteLibrary.Controllers
{
    public class AccountController : Controller
    {
        public IlibraryService _libraryService;

        public AccountController()
        {
            _libraryService = new EnityLibraryService();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = _libraryService.GetUserByLoginModel(loginModel);
                if (user != null)
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.SetAuthCookie(loginModel.Login, true);
                    return RedirectToAction("ListFreeBooks", "Library");
                }
            }
            else
            {
                ModelState.AddModelError(null, "Не привильно введен логин или пароль");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

      
    }
}

