using ManufacturingERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<LocalGovernment> LocalGovernments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            // Province → District
            modelBuilder.Entity<Province>()
                .HasMany(p => p.Districts)
                .WithOne(d => d.Province)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Province → LocalGovernment
            modelBuilder.Entity<Province>()
                .HasMany(p => p.LocalGovernments)
                .WithOne(lg => lg.Province)
                .HasForeignKey(lg => lg.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            // District → LocalGovernment
            modelBuilder.Entity<District>()
                .HasMany(d => d.LocalGovernments)
                .WithOne(lg => lg.District)
                .HasForeignKey(lg => lg.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
