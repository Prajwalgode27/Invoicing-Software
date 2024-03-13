using InvoicingSoft.Data;
using InvoicingSoft.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
namespace InvoicingSoft.Service
{
    public class StockService
    {
        InvoicingSoftEntities db = new InvoicingSoftEntities();
        public string PurchesStockOrder(HttpPostedFileBase fb, StockModel model)
        {
            string msg = "";
            //var InvoiceId = db.tblInvoices.Max(p => p.Id );
            var invoiceid = Convert.ToInt32(+1);
            string filePath = "";
            string FileName = "";
            string sysFileName = "";

            if (fb != null && fb.ContentLength > 0)
            {
                filePath = HttpContext.Current.Server.MapPath("~/Content/Pages/image");
                DirectoryInfo di = new DirectoryInfo(filePath);
                if (!di.Exists)
                {
                    di.Create();
                }
                FileName = fb.FileName;
                sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                fb.SaveAs(filePath + "//" + sysFileName);
                if (!string.IsNullOrWhiteSpace(fb.FileName))
                {
                    string afileName = HttpContext.Current.Server.MapPath("~/Content/Pages/image") + "/" + sysFileName;
                }
            }

            if (model.Id == 0)
            {
                var orderdata = new tblStock()
                {
                    Id = model.Id,
                    MasterId = 1,
                    PurchesInvoiceNo = model.PurchesInvoiceNo,
                    Particular = model.Particular,
                    ProductImage = sysFileName,
                    HSN = model.HSN,
                    UOM = model.UOM,
                    GST = model.GST,
                    MRP = model.MRP,
                    PurchesRate = model.PurchesRate,
                    SellingRate = model.SellingRate,
                    Quantity = model.Quantity,
                    Amount = model.Amount,
                    Discount = model.Discount,
                    CGST = model.CGST,
                    SGST = model.SGST,
                    Cess = model.Cess,
                    Total = model.Total,
                    NetQuantity = model.Quantity,
                    SaleQuantity = model.SaleQuantity,
                    BalanceQuantity = model.Quantity,
                    ManufacturingDate = Convert.ToDateTime(model.ManufacturingDate),
                    ExpiryDate = Convert.ToDateTime(model.ExpiryDate),
                    IsExpire = model.IsExpire,
                    CreatDate = Convert.ToDateTime(DateTime.Now),
                    CreatedBy = 1,
                    UpdateDate = Convert.ToDateTime(DateTime.Now),
                    UpdatedBy = 1,
                    IsActive = true,
                };
                db.tblStocks.Add(orderdata);
                msg = model.PurchesInvoiceNo.ToString();
                var purchesstockorder = new tblPurchesStockOrder()
                {
                    Id = model.Id,
                    MasterId = 1,
                    PurchesInvoiceNo = model.PurchesInvoiceNo,
                    Particular = model.Particular,
                    ProductImage = sysFileName,
                    HSN = model.HSN,
                    UOM = model.UOM,
                    GST = model.GST,
                    MRP = model.MRP,
                    PurchesRate = model.PurchesRate,
                    SellingRate = model.SellingRate,
                    Quantity = model.Quantity,
                    Amount = model.Amount,
                    Discount = model.Discount,
                    CGST = model.CGST,
                    SGST = model.SGST,
                    Cess = model.Cess,
                    Total = model.Total,
                    NetQuantity = model.Quantity,
                    SaleQuantity = model.SaleQuantity,
                    BalanceQuantity = model.Quantity,
                    ManufacturingDate = Convert.ToDateTime(model.ManufacturingDate),
                    ExpiryDate = Convert.ToDateTime(model.ExpiryDate),
                    IsExpire = model.IsExpire,
                    CreatDate = Convert.ToDateTime(DateTime.Now),
                    CreatedBy = 1,
                    UpdateDate = Convert.ToDateTime(DateTime.Now),
                    UpdatedBy = 1,
                    IsActive = true,
                };
                db.tblPurchesStockOrders.Add(purchesstockorder);
                //   msg = "Add order";   
                //   msg = "Add order";   
            }

            else
            {
                var getorderdata = db.tblStocks.Where(p => p.Id == model.Id).FirstOrDefault();

                if (getorderdata != null)
                {
                    getorderdata.MasterId = 1;
                    getorderdata.PurchesInvoiceNo = model.PurchesInvoiceNo;
                    getorderdata.Particular = model.Particular;
                    getorderdata.ProductImage = sysFileName;
                    getorderdata.HSN = model.HSN;
                    getorderdata.UOM = model.UOM;
                    getorderdata.GST = model.GST;
                    getorderdata.MRP = model.MRP;
                    getorderdata.PurchesRate = model.PurchesRate;
                    getorderdata.SellingRate = model.SellingRate;
                    getorderdata.Quantity = model.Quantity;
                    getorderdata.Amount = model.Amount;
                    getorderdata.Discount = model.Discount;
                    getorderdata.CGST = model.CGST;
                    getorderdata.SGST = model.SGST;
                    getorderdata.Cess = model.Cess;
                    getorderdata.Total = model.Total;
                    getorderdata.NetQuantity = model.NetQuantity;
                    getorderdata.BalanceQuantity = model.BalanceQuantity;
                    getorderdata.SaleQuantity = model.SaleQuantity;
                    getorderdata.ManufacturingDate = Convert.ToDateTime(model.ManufacturingDate);
                    getorderdata.ExpiryDate = Convert.ToDateTime(model.ExpiryDate);
                    getorderdata.UpdateDate = Convert.ToDateTime(DateTime.Now);
                    getorderdata.UpdatedBy = 1;
                    getorderdata.IsActive = true;

                };
                db.SaveChanges();
                //   msg = "Updated  Successfully";
                var purchesorder = db.tblPurchesStockOrders.Where(p => p.Id == model.Id).FirstOrDefault();

                if (purchesorder != null)
                {
                    purchesorder.MasterId = 1;
                    purchesorder.PurchesInvoiceNo = model.PurchesInvoiceNo;
                    purchesorder.Particular = model.Particular;
                    purchesorder.ProductImage = sysFileName;
                    purchesorder.HSN = model.HSN;
                    purchesorder.UOM = model.UOM;
                    purchesorder.GST = model.GST;
                    purchesorder.MRP = model.MRP;
                    purchesorder.PurchesRate = model.PurchesRate;
                    purchesorder.SellingRate = model.SellingRate;
                    purchesorder.Quantity = model.Quantity;
                    purchesorder.Amount = model.Amount;
                    purchesorder.Discount = model.Discount;
                    purchesorder.CGST = model.CGST;
                    purchesorder.SGST = model.SGST;
                    purchesorder.Cess = model.Cess;
                    purchesorder.Total = model.Total;
                    purchesorder.NetQuantity = model.NetQuantity;
                    purchesorder.BalanceQuantity = model.BalanceQuantity;
                    purchesorder.SaleQuantity = model.SaleQuantity;
                    purchesorder.ManufacturingDate = Convert.ToDateTime(model.ManufacturingDate);
                    purchesorder.ExpiryDate = Convert.ToDateTime(model.ExpiryDate);
                    purchesorder.UpdateDate = Convert.ToDateTime(DateTime.Now);
                    purchesorder.UpdatedBy = 1;
                    purchesorder.IsActive = true;

                };
                msg = "update";
                db.SaveChanges();
            }
            db.SaveChanges();
            return msg;
        }
        public List<StockModel> GetProductListByInvoiceNo(int MasterId, string PurchesInvoiceNo)
        {
            List<StockModel> lstproduct = new List<StockModel>();
            var Product = db.tblStocks.Where(p => p.MasterId == MasterId && p.PurchesInvoiceNo == PurchesInvoiceNo).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new StockModel()
                    {
                        Id = product.Id,
                        MasterId = 1,
                        PurchesInvoiceNo = product.PurchesInvoiceNo,
                        Particular = product.Particular,
                        ProductImage = product.ProductImage,
                        HSN = product.HSN,
                        UOM = product.UOM,
                        GST = product.GST,
                        MRP = product.MRP,
                        PurchesRate = product.PurchesRate,
                        SellingRate = product.SellingRate,
                        Quantity = product.Quantity,
                        Amount = product.Amount,
                        Discount = product.Discount,
                        CGST = product.CGST,
                        SGST = product.SGST,
                        Cess = product.Cess,
                        Total = product.Total,
                        NetQuantity = product.Quantity,
                        SaleQuantity = product.SaleQuantity,
                        BalanceQuantity = product.Quantity,
                        ManufacturingDate = Convert.ToDateTime(product.ManufacturingDate).ToShortDateString(),
                        ExpiryDate = Convert.ToDateTime(product.ExpiryDate).ToShortDateString(),
                        IsExpire = product.IsExpire,
                        CreatDate = Convert.ToDateTime(product.CreatDate).ToShortDateString(),
                        CreatedBy = product.CreatedBy,
                        UpdateDate = Convert.ToDateTime(product.UpdateDate).ToShortDateString(),
                        UpdatedBy = product.UpdatedBy,
                        IsActive = product.IsActive,
                    });
                }
            }
            return lstproduct;
        }
        public List<StockModel> GetallPurchessorderbyInvoiceNo(int MasterId, string PurchesInvoiceNo)
        {
            List<StockModel> lstproduct = new List<StockModel>();
            var Product = db.tblPurchesStockOrders.Where(p => p.MasterId == MasterId && p.PurchesInvoiceNo == PurchesInvoiceNo).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new StockModel()
                    {
                        Id = product.Id,
                        MasterId = 1,
                        PurchesInvoiceNo = product.PurchesInvoiceNo,
                        Particular = product.Particular,
                        ProductImage = product.ProductImage,
                        HSN = product.HSN,
                        UOM = product.UOM,
                        GST = product.GST,
                        MRP = product.MRP,
                        PurchesRate = product.PurchesRate,
                        SellingRate = product.SellingRate,
                        Quantity = product.Quantity,
                        Amount = product.Amount,
                        Discount = product.Discount,
                        CGST = product.CGST,
                        SGST = product.SGST,
                        Cess = product.Cess,
                        Total = product.Total,
                        NetQuantity = product.Quantity,
                        SaleQuantity = product.SaleQuantity,
                        BalanceQuantity = product.Quantity,
                        ManufacturingDate = Convert.ToDateTime(product.ManufacturingDate).ToShortDateString(),
                        ExpiryDate = Convert.ToDateTime(product.ExpiryDate).ToShortDateString(),
                        IsExpire = product.IsExpire,
                        CreatDate = Convert.ToDateTime(product.CreatDate).ToShortDateString(),
                        CreatedBy = product.CreatedBy,
                        UpdateDate = Convert.ToDateTime(product.UpdateDate).ToShortDateString(),
                        UpdatedBy = product.UpdatedBy,
                        IsActive = product.IsActive,
                    });
                }
            }
            return lstproduct;
        }
        public StockModel TotalPurchesOrderTotal(int MasterId, string PurchesInvoiceNo)
        {
            StockModel model = new StockModel();
            try
            {
                model.TotalPurchesQuantity = (from emp in db.tblStocks.Where(p => p.PurchesInvoiceNo == PurchesInvoiceNo).ToList()
                                              select emp).Sum(e => Convert.ToDecimal(e.Quantity));
                model.ProductTaxableAmount = (from amt in db.tblStocks.Where(p => p.PurchesInvoiceNo == PurchesInvoiceNo).ToList()
                                              select amt).Sum(e => Convert.ToDecimal(e.Amount));
                model.TotalProductDiscount = (from amt in db.tblStocks.Where(p => p.PurchesInvoiceNo == PurchesInvoiceNo).ToList()
                                              select amt).Sum(e => Convert.ToDecimal(e.Discount));
                model.TotalPurchesCGST = (from amt in db.tblStocks.Where(p => p.PurchesInvoiceNo == PurchesInvoiceNo).ToList()
                                          select amt).Sum(e => Convert.ToDecimal(e.CGST));
                model.TotalPurchesSGST = (from amt in db.tblStocks.Where(p => p.PurchesInvoiceNo == PurchesInvoiceNo).ToList()
                                          select amt).Sum(e => Convert.ToDecimal(e.SGST));
                model.TotalPurchrsCESS = (from amt in db.tblStocks.Where(p => p.PurchesInvoiceNo == PurchesInvoiceNo).ToList()
                                          select amt).Sum(e => Convert.ToDecimal(e.Cess));

                model.PurchesTotalAmount = model.ProductTaxableAmount - model.TotalProductDiscount + model.TotalPurchesCGST + model.TotalPurchesSGST + model.TotalPurchrsCESS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public List<StockModel> GetStockList(int MasterId)
        {
            List<StockModel> lstproduct = new List<StockModel>();
            var Product = db.tblStocks.Where(p => p.MasterId == MasterId).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new StockModel()
                    {
                        Id = product.Id,
                        MasterId = 1,
                        PurchesInvoiceNo = product.PurchesInvoiceNo,
                        Particular = product.Particular,
                        ProductImage = product.ProductImage,
                        HSN = product.HSN,
                        UOM = product.UOM,
                        GST = product.GST,
                        MRP = product.MRP,
                        PurchesRate = product.PurchesRate,
                        SellingRate = product.SellingRate,
                        Quantity = product.Quantity,
                        Amount = product.Amount,
                        Discount = product.Discount,
                        CGST = product.CGST,
                        SGST = product.SGST,
                        Cess = product.Cess,
                        Total = product.Total,
                        NetQuantity = product.Quantity,
                        SaleQuantity = product.SaleQuantity,
                        BalanceQuantity = product.Quantity,
                        ManufacturingDate = Convert.ToDateTime(product.ManufacturingDate).ToShortDateString(),
                        ExpiryDate = Convert.ToDateTime(product.ExpiryDate).ToShortDateString(),
                        IsExpire = product.IsExpire,
                        CreatDate = Convert.ToDateTime(product.CreatDate).ToShortDateString(),
                        CreatedBy = product.CreatedBy,
                        UpdateDate = Convert.ToDateTime(product.UpdateDate).ToShortDateString(),
                        UpdatedBy = product.UpdatedBy,
                        IsActive = product.IsActive,
                    });
                }

            }
            return lstproduct;
        }
        public StockModel TotalStock(int MasterId)
        {
            DateTime now = DateTime.UtcNow;
            StockModel model = new StockModel();
            try
            {
                model.TotalStock = db.tblStocks.Where(p => p.MasterId == MasterId).Count();
                model.TotalQuantity = (from emp in db.tblStocks.Where(p => p.MasterId == MasterId).ToList()
                                       select emp).Sum(e => Convert.ToDecimal(e.Quantity));
                //model.TotalStockAmount = (from amt in db.tblStocks.Where(p => p.MasterId == MasterId).ToList()
                //select amt).Sum(e => Convert.ToDecimal( e.Total));
                decimal totalStockAmount = db.tblStocks.Where(p => p.MasterId == MasterId).ToList().Sum(e => Math.Abs(Convert.ToDecimal(e.Total)));
                model.TotalStockAmount = totalStockAmount;
                var nowDate = DateTime.Now;
                model.TotalExpireStock = db.tblStocks.Where(p => p.MasterId == MasterId && p.ExpiryDate <= nowDate || p.ExpiryDate == DateTime.Now).Count();
                model.TotalExpireQuantity = (from emp in db.tblStocks.Where(p => p.MasterId == MasterId && p.ExpiryDate <= nowDate || p.ExpiryDate == DateTime.Now).ToList()
                                             select emp).Sum(e => Convert.ToDecimal(e.Quantity));
                model.TotalExpireStockAmount = (from amt in db.tblStocks.Where(p => p.MasterId == MasterId && p.ExpiryDate <= nowDate || p.ExpiryDate == DateTime.Now).ToList()
                                                select amt).Sum(e => Math.Abs(Convert.ToDecimal(e.Total)));
                var availableStocks = db.tblStocks.Where(p => p.MasterId == MasterId && p.ExpiryDate > nowDate && p.Quantity > 0).ToList();
                model.TotalAvailableStockAmount = availableStocks.Sum(e => Math.Abs(Convert.ToDecimal(e.Total)));
                model.TotalAvailableStockQuantity = availableStocks.Sum(e => Convert.ToDecimal(e.Quantity));
                model.TotalAvailableStock = db.tblStocks.Where(p => p.MasterId == MasterId && p.ExpiryDate > nowDate && p.Quantity > 0).Count();
                model.TotalUnAvailableStock = db.tblStocks.Where(p => p.MasterId == MasterId && p.Quantity <= 5 || p.ExpiryDate <= nowDate && p.Quantity > 0).Count();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public List<StockModel> GetAvailableStockList(int MasterId)
        {
            List<StockModel> lstproduct = new List<StockModel>();
            var nowDate = DateTime.Now;
            var availableStocks = db.tblStocks.Where(p => p.MasterId == MasterId && p.ExpiryDate > nowDate && p.Quantity > 0).ToList();
            // var Product = db.tblStocks.Where(p => p.MasterId == MasterId && p.ExpiryDate <= nowDate || p.ExpiryDate == DateTime.Now).OrderByDescending(product => product.ExpiryDate).ToList();
            if (availableStocks != null)
            {
                foreach (var product in availableStocks)
                {
                    lstproduct.Add(new StockModel()
                    {
                        Id = product.Id,
                        MasterId = 1,
                        PurchesInvoiceNo = product.PurchesInvoiceNo,
                        Particular = product.Particular,
                        ProductImage = product.ProductImage,
                        HSN = product.HSN,
                        UOM = product.UOM,
                        GST = product.GST,
                        MRP = product.MRP,
                        PurchesRate = product.PurchesRate,
                        SellingRate = product.SellingRate,
                        Quantity = product.Quantity,
                        Amount = product.Amount,
                        Discount = product.Discount,
                        CGST = product.CGST,
                        SGST = product.SGST,
                        Cess = product.Cess,
                        Total = product.Total,
                        NetQuantity = product.Quantity,
                        SaleQuantity = product.SaleQuantity,
                        BalanceQuantity = product.Quantity,
                        ManufacturingDate = Convert.ToDateTime(product.ManufacturingDate).ToShortDateString(),
                        ExpiryDate = Convert.ToDateTime(product.ExpiryDate).ToShortDateString(),
                        IsExpire = product.IsExpire,
                        CreatDate = Convert.ToDateTime(product.CreatDate).ToShortDateString(),
                        CreatedBy = product.CreatedBy,
                        UpdateDate = Convert.ToDateTime(product.UpdateDate).ToShortDateString(),
                        UpdatedBy = product.UpdatedBy,
                        IsActive = product.IsActive,
                    });
                }

            }
            return lstproduct;
        }
        public List<StockModel> GetExpireStockList(int MasterId)
        {
            List<StockModel> lstproduct = new List<StockModel>();
            var nowDate = DateTime.Now;
            var Product = db.tblStocks.Where(p => p.MasterId == MasterId && p.ExpiryDate <= nowDate || p.ExpiryDate == DateTime.Now).OrderByDescending(product => product.ExpiryDate).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new StockModel()
                    {
                        Id = product.Id,
                        MasterId = 1,
                        PurchesInvoiceNo = product.PurchesInvoiceNo,
                        Particular = product.Particular,
                        ProductImage = product.ProductImage,
                        HSN = product.HSN,
                        UOM = product.UOM,
                        GST = product.GST,
                        MRP = product.MRP,
                        PurchesRate = product.PurchesRate,
                        SellingRate = product.SellingRate,
                        Quantity = product.Quantity,
                        Amount = product.Amount,
                        Discount = product.Discount,
                        CGST = product.CGST,
                        SGST = product.SGST,
                        Cess = product.Cess,
                        Total = product.Total,
                        NetQuantity = product.Quantity,
                        SaleQuantity = product.SaleQuantity,
                        BalanceQuantity = product.Quantity,
                        ManufacturingDate = Convert.ToDateTime(product.ManufacturingDate).ToShortDateString(),
                        ExpiryDate = Convert.ToDateTime(product.ExpiryDate).ToShortDateString(),
                        IsExpire = product.IsExpire,
                        CreatDate = Convert.ToDateTime(product.CreatDate).ToShortDateString(),
                        CreatedBy = product.CreatedBy,
                        UpdateDate = Convert.ToDateTime(product.UpdateDate).ToShortDateString(),
                        UpdatedBy = product.UpdatedBy,
                        IsActive = product.IsActive,
                    });
                }

            }
            return lstproduct;
        }
        public List<StockModel> GetUnavalibleStockList(int MasterId)
        {
            List<StockModel> lstproduct = new List<StockModel>();
            var nowDate = DateTime.Now;

            var Product = db.tblStocks.Where(p => p.MasterId == MasterId && p.Quantity <= 2 || p.ExpiryDate <= nowDate).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new StockModel()
                    {
                        Id = product.Id,
                        MasterId = 1,
                        PurchesInvoiceNo = product.PurchesInvoiceNo,
                        Particular = product.Particular,
                        ProductImage = product.ProductImage,
                        HSN = product.HSN,
                        UOM = product.UOM,
                        GST = product.GST,
                        MRP = product.MRP,
                        PurchesRate = product.PurchesRate,
                        SellingRate = product.SellingRate,
                        Quantity = product.Quantity,
                        Amount = product.Amount,
                        Discount = product.Discount,
                        CGST = product.CGST,
                        SGST = product.SGST,
                        Cess = product.Cess,
                        Total = product.Total,
                        NetQuantity = product.Quantity,
                        SaleQuantity = product.SaleQuantity,
                        BalanceQuantity = product.Quantity,
                        ManufacturingDate = Convert.ToDateTime(product.ManufacturingDate).ToShortDateString(),
                        ExpiryDate = Convert.ToDateTime(product.ExpiryDate).ToShortDateString(),
                        IsExpire = product.IsExpire,
                        CreatDate = Convert.ToDateTime(product.CreatDate).ToShortDateString(),
                        CreatedBy = product.CreatedBy,
                        UpdateDate = Convert.ToDateTime(product.UpdateDate).ToShortDateString(),
                        UpdatedBy = product.UpdatedBy,
                        IsActive = product.IsActive,
                    });
                }

            }
            return lstproduct;
        }
        public List<StockModel> purchespruductSearch(string Prefix)
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            List<StockModel> lstproduct = new List<StockModel>();
            var Product = db.tblStocks.Where(p => p.MasterId == 1 && p.Particular.Contains(Prefix)).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new StockModel()
                    {
                        Id = product.Id,
                        MasterId = 1,
                        PurchesInvoiceNo = product.PurchesInvoiceNo,
                        Particular = product.Particular,
                        ProductImage = product.ProductImage,
                        HSN = product.HSN,
                        UOM = product.UOM,
                        GST = product.GST,
                        MRP = product.MRP,
                        PurchesRate = product.PurchesRate,
                        SellingRate = product.SellingRate,
                        Quantity = product.Quantity,
                        Amount = product.Amount,
                        Discount = product.Discount,
                        CGST = product.CGST,
                        SGST = product.SGST,
                        Cess = product.Cess,
                        Total = product.Total,
                        NetQuantity = product.Quantity,
                        SaleQuantity = product.SaleQuantity,
                        BalanceQuantity = product.Quantity,
                        ManufacturingDate = Convert.ToDateTime(product.ManufacturingDate).ToShortDateString(),
                        ExpiryDate = Convert.ToDateTime(product.ExpiryDate).ToShortDateString(),
                        IsExpire = product.IsExpire,
                        CreatDate = Convert.ToDateTime(product.CreatDate).ToShortDateString(),
                        CreatedBy = product.CreatedBy,
                        UpdateDate = Convert.ToDateTime(product.UpdateDate).ToShortDateString(),
                        UpdatedBy = product.UpdatedBy,
                        IsActive = product.IsActive,
                    });
                }
            }
            return lstproduct;
        }
        public StockModel UpdateProductOrder(int productIds)
        {
            StockModel model = new StockModel();
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            var editProduct = db.tblStocks.Where(p => p.Id == productIds).FirstOrDefault();
            if (editProduct != null)
            {
                model.Id = editProduct.Id;
                model.MasterId = 1;
               model.PurchesInvoiceNo = editProduct.PurchesInvoiceNo;
               model.Particular = editProduct.Particular;
               model.ProductImage = editProduct.ProductImage;
               model.HSN = editProduct.HSN;
               model.UOM = editProduct.UOM;
               model.GST = editProduct.GST;
               model.MRP = editProduct.MRP;
               model.PurchesRate = editProduct.PurchesRate;
               model.SellingRate = editProduct.SellingRate;
               model.Quantity = editProduct.Quantity;
              model.Amount = editProduct.Amount;
              model.Discount = editProduct.Discount;
              model.CGST = editProduct.CGST;
              model.SGST = editProduct.SGST;
              model.Cess = editProduct.Cess;
              model.Total = editProduct.Total;
              model.NetQuantity = editProduct.NetQuantity;
              model.BalanceQuantity = editProduct.BalanceQuantity;
              model.SaleQuantity = editProduct.SaleQuantity;
              model.ManufacturingDate = Convert.ToDateTime(editProduct.ManufacturingDate).ToShortDateString();
              model.ExpiryDate = Convert.ToDateTime(editProduct.ExpiryDate).ToShortDateString();
              model.UpdateDate = Convert.ToDateTime(DateTime.Now).ToShortDateString();
              model.UpdatedBy = 1;
              model.IsActive = true;
            }
            return model;   
        }
   
    }
}

