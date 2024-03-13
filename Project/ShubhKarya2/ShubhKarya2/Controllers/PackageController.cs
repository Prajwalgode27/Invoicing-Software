using ShubhKarya2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShubhKarya.Controllers
{
    public class PackageController : Controller
    {
        // GET: Package
        public ActionResult PackageIndex()
        {
            if (Session["IsAdmin"] == "NAYANR")
            {

                return View();
            }
            else {
                Session["IsAdmin"] = "YANANR";
                return View("..\\Admin\\AdminLogin");
            }
        }
       
        public ActionResult SavePackage(PackageModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = new PackageModel().SavePackage(fb, model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPackageList()
        {
            try
            {
                return Json(new { model = (new PackageModel().GetPackageList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeletePackage(int Id)
        {
            try
            {
                return Json(new { model = (new PackageModel().DeletePackage(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditPackage(int Id)
        {
            try
            {
                return Json(new { model = (new PackageModel().EditPackage(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DetailPackage(int Id)
        {
            try
            {
                return Json(new { model = (new PackageModel().EditPackage(Id)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ddlPackageList()
        {
            try
            {
                return Json(new { model = (new PackageModel().GetPackageList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}