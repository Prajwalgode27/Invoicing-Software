using Microsoft.Ajax.Utilities;
using ShubhKarya2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShubhKarya.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
       
        public ActionResult MemberIndex()
        {
            if ( Session["IsAdmin"] == "NAYANR")
            {
                return View();
            }
            else
            {
                Session["IsAdmin"] = "YANANR";
                return View("..\\Admin\\AdminLogin");
            }
        }
        public ActionResult PremiumIndex(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult PremiumProfileIndex(int Id)
        {
            ViewBag.MemberId = Id;
            return View();
        }
        public ActionResult MemberListIndex()
        {
            return View();
        }
        public ActionResult UpdateProfileIndex()
        {
            return View();
        }
        public ActionResult ProfileIndex()
        {
            ViewBag.MemberId= Session["Id"];
            return View();
        }
       
        public ActionResult saveMember(MemberModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = new MemberModel().saveMember(fb, model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetMemberList()
        {
            try
            {
                return Json(new { model = (new MemberModel().GetMemberList()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetSubscriptionMemberId(int Id)
        {
            try
            {
                return Json(new { model = (new MemberModel().GetSubscriptionMemberId(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteMember(int Id)
        {
            try
            {
                return Json(new { model = (new MemberModel().DeleteMember(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditMember(int Id)
        {
            try
            {
                return Json(new { model = (new MemberModel().EditMember(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DetailMember(int Id)
        {
            try
            {
                return Json(new { model = (new MemberModel().EditMember(Id)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult GetallActiveMember()
        {
            try
            {
                return Json(new { model = (new MemberModel().GetallActiveMember()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetBridelst()
        {
            try
            {
                return Json(new { model = (new MemberModel().GetBridelst()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetGroomlst()
        {
            try
            {
                return Json(new { model = (new MemberModel().GetGroomlst()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
    
}