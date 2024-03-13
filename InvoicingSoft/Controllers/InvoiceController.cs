using InvoicingSoft.Models;
using InvoicingSoft.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingSoft.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult InvoiceIndex()
        {
            return View();
        }
        public ActionResult InvoiceListIndex()
        {
            return View();
        }
        public ActionResult InvoiceDetailsIndex(string InvoiceNo,bool isPrint)
        {
            // ViewBag.InvoiceNo= "Inc-2024-1";
           ViewBag.InvoiceNo = InvoiceNo;
            ViewBag.IsPrint = isPrint.ToString();
            return View();
        }
        public ActionResult GetInvoiceNo()
        {
            try
            {
                return Json(new { Message = (new InvoiceService().GetInvoiceId()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SaveCustomerOrder(CustomerOrderInvoice model)
        {
            try
            {
                return Json(new { Message = (new CustomerOrderInvoiceService().SaveCustomerOrder(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetcustomerordertList(string InvoiceNo)
        {
            try
            {
                return Json(new { Message = (new CustomerOrderInvoiceService().GetcustomerordertList(InvoiceNo)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TotalCustomerOrderDetails(string InvoiceNo)
        {
            try
            {
                return Json(new { Message = (new CustomerOrderInvoiceService().TotalCustomerOrderDetails(InvoiceNo)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SaveCustomerInvoice(InvoiceModel model)
        {
            try
            {
                return Json(new { Message = (new InvoiceService().SaveCustomerInvoice(model)) },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult InvoiceList(int MasterId)
        {
            try
            {
                return Json(new { Message = (new InvoiceService().GetInvoiceList(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CustomerInvoiceList(int CustomerId)
        {
            try
            {
                return Json(new { Message = (new InvoiceService().CustomerInvoiceList(CustomerId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult InvoiceDetails(string InvoiceNo)
        {
            try
            {
                return Json(new { Message = (new InvoiceService().InvoiceDetails(InvoiceNo)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}