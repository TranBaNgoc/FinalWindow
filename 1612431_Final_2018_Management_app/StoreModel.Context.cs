﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1612431_Final_2018_Management_app
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StoreManagementEntities : DbContext
    {
        public StoreManagementEntities()
            : base("name=StoreManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CodePromotion> CodePromotions { get; set; }
        public virtual DbSet<CouponPromotion> CouponPromotions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DetailBill> DetailBills { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalePercentPromotion> SalePercentPromotions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
