﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InvoicingSoftEntities : DbContext
    {
        public InvoicingSoftEntities()
            : base("name=InvoicingSoftEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblCustomerAccount> tblCustomerAccounts { get; set; }
        public virtual DbSet<tblInvoice> tblInvoices { get; set; }
        public virtual DbSet<tblLoginHistory> tblLoginHistories { get; set; }
        public virtual DbSet<tblMaster> tblMasters { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblCustomerOrder> tblCustomerOrders { get; set; }
        public virtual DbSet<tblStock> tblStocks { get; set; }
        public virtual DbSet<tblStockInvoice> tblStockInvoices { get; set; }
        public virtual DbSet<tblPurchesStockOrder> tblPurchesStockOrders { get; set; }
    }
}