using InvoicingSoft.Data;
using InvoicingSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingSoft.Service
{
    public class StockInvoiceService
    {
        InvoicingSoftEntities db = new InvoicingSoftEntities();

        public string GetPurchesInvoiceId()
        {
            // var getMaaxId = db.tblInvoices.Max(p => p.InvoiceNo);

            int getMaaxId = 0;
            getMaaxId = Convert.ToInt32(db.tblStockInvoices.Max(p => (int?)p.Id) ?? 0);
            var f = Convert.ToInt32(getMaaxId);
            var g = f++;
            var InvoiceId = DateTime.Now.ToString("yyyy") + g;

            //var r = f.ToString().PadLeft(5, '0');
            return InvoiceId;
        }

        public string SavePurchesDetails(StockInvoiceModel model)
        {
            string msg = "";
            if (model.Id == 0)
            {
                var invoicedata = new tblStockInvoice()
                {
                    Id = model.Id,
                    MasterId = 1,
                    PurchesInvoiceNo = model.PurchesInvoiceNo,
                    Quantity = model.Quantity,
                    TaxAmount = (decimal)model.TaxAmount,
                    Discount = (decimal)model.Discount,
                    CGST = (decimal)model.CGST,
                    OtherCharge = (decimal)model.OtherCharge,
                    SGST = (decimal)model.SGST,
                    CESS = (decimal)model.CESS,
                    TotalAmount = (decimal)model.TotalAmount,
                    CrateDate = Convert.ToDateTime(DateTime.Now),
                    CreateBy = 1,
                    UpdateDate = (DateTime)DateTime.Now,
                    UpdateBy = 1,
                    isActive = true,
                };
                db.tblStockInvoices.Add(invoicedata);
                db.SaveChanges();
                // msg = "GentrateInvoice";
                msg = model.PurchesInvoiceNo.ToString();
            }
            return msg;
        }
        public List<StockInvoiceModel> GetPurchesList(int MasterId)
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            List<StockInvoiceModel> lstInvoice = new List<StockInvoiceModel>();

            var Data= db.tblStockInvoices.Where(p=>p.MasterId == MasterId).ToList();

            if (Data != null)
            {
                foreach (var data in Data)
                {
                    lstInvoice.Add(new StockInvoiceModel()
                    {
                        Id = data.Id,
                        PurchesInvoiceNo = data.PurchesInvoiceNo,
                        Quantity = data.Quantity,
                        TaxAmount = (decimal)data.TaxAmount,
                        Discount = (decimal)data.Discount,
                        CGST = (decimal)data.CGST,
                        OtherCharge = (decimal)data.OtherCharge,
                        SGST = (decimal)data.SGST,
                        CESS = (decimal)data.CESS,
                        TotalAmount = (decimal)data.TotalAmount,
                        CrateDate = Convert.ToDateTime(data.CrateDate).ToShortDateString(),
                    });
                }

            }
            return lstInvoice;
        }
        public List<ProductModel> pruductSearch(string Prefix)
        {
            InvoicingSoftEntities db = new InvoicingSoftEntities();
            List<ProductModel> lstproduct = new List<ProductModel>();
            var Product = db.tblProducts.Where(p => p.MasterId == 1 && p.Particular.Contains(Prefix)).ToList();
            if (Product != null)
            {
                foreach (var product in Product)
                {
                    lstproduct.Add(new ProductModel()
                    {
                        Id = product.Id,
                        Particular = product.Particular,
                        UOM = product.UOM,
                        HSN = product.HSN,
                        GST = product.GST,
                        MRP = decimal.Round(product.MRP, 2, MidpointRounding.AwayFromZero),
                        Rate = (decimal)product.Rate,
                        CrateDate = Convert.ToDateTime(product.CrateDate).ToString("dd/MM/yyyy"),
                    });
                }
            }
            return lstproduct;
        }
    }
}