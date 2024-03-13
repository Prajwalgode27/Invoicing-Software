using ShubhKarya2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShubhKarya.Controllers
{
    public class MembershipController : Controller
    {
        // GET: Membership
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MembershipIndex()
        {
            if (Session["IsAdmin"] == "NAYANR")
            {
                return View();
            }
            else
            {
                Session["IsAdmin"] = "YANANR";
                return View("..\\Admin\\AdminLogin");
            }
        }

        public ActionResult SaveMem(MembershipModel model)
            {
            try
            {
                return Json(new { Message = new MembershipModel().SaveMemberShip(model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetMembershipList()
        {
            try
            {
                return Json(new { model = (new MembershipModel().GetMembershipList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteMembership(int Id)
        {
            try
            {
                return Json(new { model = (new MembershipModel().DeleteMembership(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditMembership(int Id)
        {
            try
            {
                return Json(new { model = (new MembershipModel().EditMembership(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult DetailMembership(int Id)
        //{
        //    try
        //    {
        //        return Json(new { model = (new MembershipModel().EditMembership(Id)) },
        //            JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
        //    }


        //}

        
    }
}