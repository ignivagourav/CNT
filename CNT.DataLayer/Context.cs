using CNT.Models;
using CNT.Models.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNT.DataLayer
{
    public class Context : DbContext, IContext, IDisposable
    {
        public Context()
           : base("name=CompareNewTyresEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
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
