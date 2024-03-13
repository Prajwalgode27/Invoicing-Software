using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingSoft.Models
{
    public class InvoiceModel
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; }
        public int MasterId { get; set; }
        public int CustomerId { get; set; }
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
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string GSTNo { get; set; }
        public string Mobile { get; set; }
        public string Email { get;  set; }
        public object PreveusBalance { get; internal set; }
        public decimal? PaidBalance { get; internal set; }
        public decimal? BalanceAmount { get; internal set; }
        public string PaymentMode { get; internal set; }
        public string TransactionNo { get; internal set; }
    }

    public class CustomerOrderInvoice
    {
        public long Id { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<int> MasterId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Particular { get; set; }
        public string HSN { get; set; }
        public string UOM { get; set; }
        public string GST { get; set; }
        public decimal MRP { get; set; }
        public decimal Rate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> CESS { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<System.DateTime> CrateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string Quantity { get; set; }
        public decimal TotalQuantity { get; internal set; }
        public decimal TaxableAmount { get; internal set; }
        public decimal TotalDiscount { get; internal set; }
        public decimal TotalCGST { get; internal set; }
        public decimal TotalSGST { get; internal set; }
        public decimal TotalCESS { get; internal set; }
        public List<GSTDetails> GSTDetails { get; set; }
        public decimal TotalExpireQuantity { get; internal set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string GSTNo { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }

    public class GSTDetails
    {
        public string GST { get; set;}
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> SGST { get; set; }

    }
}