﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShubhKarya2.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShubhkaryaEntities : DbContext
    {
        public ShubhkaryaEntities()
            : base("name=ShubhkaryaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblPackage> tblPackages { get; set; }
        public virtual DbSet<tblReg> tblRegs { get; set; }
        public virtual DbSet<tblMembership> tblMemberships { get; set; }
    }
}
