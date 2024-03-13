using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingSoft.Models
{
    public class StockInvoiceModel
    {
        public long Id { get; set; }
        public string PurchesInvoiceNo { get; set; }
        public Nullable<int> MasterId { get; set; }
        public string Quantity { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
        public Nullable<decimal> CESS { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string CrateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}