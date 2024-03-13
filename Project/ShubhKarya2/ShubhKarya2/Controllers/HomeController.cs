using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShubhKarya2.Data;
using System.Web.Security;
using ShubhKarya2.Models;


namespace ShubhKarya2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult test()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult saveregistration(RegModel model)
        {
            {
                try
                {

                    HttpPostedFileBase fb = null;
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        fb = Request.Files[i];
                    }
                    return Json(new { Message = new RegModel().SaveReg(fb, model) }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }

        }
        public ActionResult UserLogin(RegModel model)
        {
            if (ModelState.IsValid)
            {
                ShubhkaryaEntities db = new ShubhkaryaEntities();
                var log = db.tblRegs.Where(p => (p.Mobile == model.Mobile || p.Email==model.Email) &&( p.Password == model.Password )).FirstOrDefault();
                if (log != null)
                {
                    Session["Id"] = log.Id;
                    return View("..\\Home\\Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password.");
                }
            }
            return View("..\\Home\\Index", model);
        }
        
        //public ActionResult UserDashBoard()
        //{
        //    return View("..\\Home\\Index");

        //}
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Home\\Index");
        }
    }
    
}
  