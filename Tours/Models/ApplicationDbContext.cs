using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Tours.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Package> Packages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                .HasRequired(t => t.Tour)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Package>()
                .HasRequired(t => t.Service)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Package>()
                .HasRequired(t => t.Vehicle)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}