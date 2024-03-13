using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicingSoft.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string Particular { get; set; }
        public string HSN { get; set; }
        public string UOM { get; set; }
        public string GST { get; set; }
        public decimal MRP { get; set; }
        public decimal Rate { get; set; }
        public string CrateDate { get; set; }
        public int CreateBy { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public int UpdateBy { get; set; }
        public bool isActive { get; set; }
        public string CustomerName { get; internal set; }
        public string Mobile { get; internal set; }
        public string Email { get; internal set; }
        public string GSTNo { get; internal set; }
        public string Address { get; internal set; }
        public string ZipCode { get; internal set; }
        public string State { get; internal set; }
        public string City { get; internal set; }
    }
}