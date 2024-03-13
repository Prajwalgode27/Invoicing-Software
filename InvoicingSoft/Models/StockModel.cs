using InvoicingSoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingSoft.Models
{
    public class StockModel
    {
        public long Id { get; set; }
        public Nullable<int> MasterId { get; set; }
        public string PurchesInvoiceNo { get; set; }
        public string Particular { get; set; }
        public string ProductImage { get; set; }
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
        public string ManufacturingDate { get; set; }
        public string ExpiryDate { get; set; }
        public Nullable<bool> IsExpire { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatDate { get; set; }
        public string UpdateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public decimal TotalPurchesQuantity { get; set; }
        public decimal ProductTaxableAmount { get; set; }
        public decimal TotalProductDiscount { get; set; }
        public decimal TotalPurchesCGST { get; set; }
        public decimal TotalPurchrsCESS { get; set; }
        public decimal TotalPurchesSGST { get; set; }
        public decimal PurchesTotalAmount { get; set; }
        public decimal TotalStock { get; internal set; }
        public decimal TotalStockAmount { get; internal set; }
        public decimal TotalQuantity { get; internal set; }
        public decimal TotalExpireStockAmount { get; internal set; }
        public decimal TotalExpireQuantity { get; internal set; }
        public int TotalExpireStock { get; internal set; }
        public decimal TotalAvailableStockAmount { get; internal set; }
        public decimal TotalAvailableStockQuantity { get; internal set; }
        public object TotalAvailableStock { get; internal set; }
        public int TotalUnAvailableStock { get; internal set; }
        public List<tblStock> TotalUnAvailableList { get; internal set; }
    }
}