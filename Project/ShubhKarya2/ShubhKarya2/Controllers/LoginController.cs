//using ShubhKarya.Data;
//using ShubhKarya.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;

//namespace ShubhKarya.Controllers
//{
//    public class LoginController : Controller
//    {
//        // GET: Login
//        public ActionResult LoginIndex()
//        {
//            return View();
//        }
//        public ActionResult LoginIN(RegModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                ShubhKaryaEntities db = new ShubhKaryaEntities();
//                var login = db.tblRegs.Where(p => p.Email == model.Email && p.Password == model.Password).FirstOrDefault();
//                if (login != null)

//                //if (model.Email == "Aishwarya" && model.Pincode == "Aish@123")
//                {
//                    Session["FullName"] = login.FullName.ToString();

//                    return View("..\\Admin\\AdminIndex");
//                    //return RedirectToAction("UserDashBoard");
//                }
//                else
//                {
//                    ModelState.AddModelError("", "Invalid User name or password.");
//                }
//            }
//            return View("..\\Login\\LoginIndex", model);
//        }
//        //public ActionResult UserDashBoard()
//        //{
//        //    //return View("..\\Login\\Index");
//        //    return View("..\\Admin\\Index");
//        //}
//        public ActionResult Logout()
//        {
//            Session.RemoveAll();
//            FormsAuthentication.SignOut();
//            return View("..\\Login\\LoginIndex");
//        }
//    }
//}