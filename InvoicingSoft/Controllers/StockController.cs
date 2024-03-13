using InvoicingSoft.Models;
using InvoicingSoft.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingSoft.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult StockReportIndex()
        {
            return View();
        }
        public ActionResult ExpireStockReportIndex()
        {
            return View();
        }
        public ActionResult AvailableStockReportIndex()
        {
            return View();
        }
        public ActionResult UnavailableStockReportIndex()
        {
            return View();
        }
        public ActionResult GetPurchesInvoiceId()
        {
            try
            {
                return Json(new { Message = (new StockInvoiceService().GetPurchesInvoiceId()) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SavePurchesDetails(StockInvoiceModel model)
        {
            try
            {
                return Json(new { Message = (new StockInvoiceService().SavePurchesDetails(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPurchesList(int MasterId)
        {
            try
            {
                return Json(new { Message = (new StockInvoiceService().GetPurchesList(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetStockList(int MasterId)
        {
            try
            {
                return Json(new { Message = (new StockService().GetStockList(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TotalStockReport(int MasterId)
        {
            try
            {
                return Json(new { Message = (new StockService().TotalStock(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ExpireStockList(int MasterId)
        {
            try
            {
                return Json(new { Message = (new StockService().GetExpireStockList(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAvailableStockList(int MasterId)
        {
            try
            {
                return Json(new { Message = (new StockService().GetAvailableStockList(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetUnavalibleStockList(int MasterId)
        {
            try
            {
                return Json(new { Message = (new StockService().GetUnavalibleStockList(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}