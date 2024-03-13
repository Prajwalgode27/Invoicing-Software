using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingSoft.Models
{
    public class CustomerModel
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> MasterId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string GSTNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Nullable<System.DateTime> CrateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
    public class CustomerAccountModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> MasterId { get; set; }
        public Nullable<decimal> PreveusBalance { get; set; }
        public Nullable<decimal> PaidBalance { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }
        public string PaymentMode { get; set; }
        public string TransactionNo { get; set; }
        public string CrateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<decimal> NewInvoiceAmount { get; set; }
        public decimal? TotalBalanceAmount { get; internal set; }
    }
}