﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNT.DataLayer
{
    using CNT.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompareNewTyresEntities : DbContext
    {
        public CompareNewTyresEntities()
            : base("name=CompareNewTyresEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<FitterProfile> FitterProfiles { get; set; }
        public virtual DbSet<FitterReview> FitterReviews { get; set; }
        public virtual DbSet<TyreImage> TyreImages { get; set; }
        public virtual DbSet<Tyre> Tyres { get; set; }
        public virtual DbSet<TyresRequest> TyresRequests { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}