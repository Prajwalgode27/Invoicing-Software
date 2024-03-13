//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InvoicingSoft.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPurchesStockOrder
    {
        public long Id { get; set; }
        public Nullable<int> MasterId { get; set; }
        public string PurchesInvoiceNo { get; set; }
        public string Particular { get; set; }
        public string UOM { get; set; }
        public string HSN { get; set; }
        public string GST { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public Nullable<decimal> PurchesRate { get; set; }
        public Nullable<decimal> SellingRate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> Cess { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> NetQuantity { get; set; }
        public Nullable<int> SaleQuantity { get; set; }
        public Nullable<int> BalanceQuantity { get; set; }
        public Nullable<System.DateTime> ManufacturingDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<bool> IsExpire { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string ProductImage { get; set; }
    }
}