using InvoicingSoft.Models;
using InvoicingSoft.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingSoft.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomerIndex()
        {
            return View();
        }
        public ActionResult CustomerInvoiceListIndex(int CustomerId)
        {
            ViewBag.CustomerId = CustomerId;
            return View();
        }
        public ActionResult SaveCustomer(CustomerModel model)
        {
            try
            {
                return Json(new { Message = (new CustomerService().SaveCustomer(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCustomerList(int MasterId)
        {
            try
            {
                return Json(new { Message = (new CustomerService().GetCustomerList(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ddlCustomerSearch(string Prefix)
        {
            try
            {
                return Json(new { Message = (new CustomerService().ddlCustomerSearch( Prefix)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteCustomer(int Id)
        {
            try
            {
                return Json(new { Message = (new CustomerService().DeleteCustomer(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCustomerDetailbyId(int Id)
        {
            try
            {
                return Json(new { Message = (new CustomerService().GetCustomerDetailbyId(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}