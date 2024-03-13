using InvoicingSoft.Models;
using InvoicingSoft.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingSoft.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult AccountIndex( int CustomerId)
        {
            ViewBag.customerId = CustomerId;
            return View();
        }

        public ActionResult SaveCustomerAccount(CustomerAccountModel model)
        {
            try
            {
                return Json(new { Message = (new CustomerAccountService().SaveCustomerAccount(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCustomerAccountList(int CustomerId)
        {
            try
            {
                return Json(new { Message = (new CustomerAccountService().GetCustomerAccountList(CustomerId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}