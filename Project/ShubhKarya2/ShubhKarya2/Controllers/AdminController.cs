using ShubhKarya2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShubhKarya.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
       // [Authorize]
        public ActionResult AdminIndex()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIN(AdminModel model)
        {
          
            if (model.UserName == "Admin" && model.Password == "123")
            {
                Session["IsAdmin"] = "NAYANR";
                return View("..\\Package\\PackageIndex");
            }
            else
            {
                ModelState.AddModelError("", "Invalid User name or password.");
            }

            return View("..\\Admin\\AdminLogin", model);
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Admin\\AdminLogin");
        }
    }
}