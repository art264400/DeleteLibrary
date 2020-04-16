using System;
using System.Web.Mvc;
using DeleteLibrary.Context;
using DeleteLibrary.Models.Visitors;

namespace DeleteLibrary.Filters
{
    public class LogAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            base.OnActionExecuting(filterContext);
            var visitor = new Visitor()
            {
                Ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                Url = request.RawUrl,
                Date = DateTime.UtcNow,
                Browser = request.Browser.ToString()
            };
            using (LibraryContext db= new LibraryContext())
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}