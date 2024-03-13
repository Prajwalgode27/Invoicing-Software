using InvoicingSoft.Models;
using InvoicingSoft.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicingSoft.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductIndex()
        {
            return View();
        }
        public ActionResult PurchaseProductIndex()
        {
            return View();
        }
        public ActionResult PurchaseProductReportIndex()
        {
            return View();
        }
        public ActionResult PurchesProductOrderIndex(int PurchesInvoiceNo)
        {
            ViewBag.PurchesInvoiceNo = PurchesInvoiceNo;
            return View();
        }
        public ActionResult SaveProduct(ProductModel model)
        {
            try
            {
                return Json(new { Message = (new ProductService().SaveProduct(model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetProductList(int MasterId)
        {
            try
            {
                return Json(new { Message = (new ProductService().GetProductList(MasterId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteProduct(int Id)
        {
            try
            {
                return Json(new { Message = (new ProductService().DeleteProduct(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeletePurchesProduct(List<int> productIds)
        {
            try
            {
                return Json(new { Message = (new ProductService().DeletePurchesProducts(productIds)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
}
        public ActionResult GetProductbyId(int Id)
        {
            try
            {
                return Json(new { Message = (new ProductService().GetProductbyId(Id)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult pruductSearch(string Prefix)
        {
            try
            {
                return Json(new { Message = (new ProductService().pruductSearch(Prefix)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult PurchesStockOrder(StockModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = (new StockService().PurchesStockOrder(fb,model)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetProductListByInvoiceNo(int MasterId, string PurchesInvoiceNo)
        {
            try
            {
                return Json(new { Message = (new StockService().GetProductListByInvoiceNo(MasterId, PurchesInvoiceNo)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetallPurchessorderbyInvoiceNo(int MasterId, string PurchesInvoiceNo)
        {
            try
            {
                return Json(new { Message = (new StockService().GetallPurchessorderbyInvoiceNo(MasterId, PurchesInvoiceNo)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult TotalPurchesOrderTotal(int MasterId, string PurchesInvoiceNo)
        {
            try
            {
                return Json(new { Message = (new StockService().TotalPurchesOrderTotal(MasterId, PurchesInvoiceNo)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult purchespruductSearch(string Prefix)
        {
            try
            {
                return Json(new { Message = (new StockService().purchespruductSearch( Prefix)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
       
        public ActionResult UpdateProductOrder(int productIds)
        {
            try
            {
                return Json(new { Message = (new StockService().UpdateProductOrder(productIds)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}