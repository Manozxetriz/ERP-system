using ManufacturingERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingERP.Infrastructure.Data
{
    public class RoleSeeder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role { Id = 1, Name = "Admin", Description = "System Administrator" },
                new Role { Id = 2, Name = "Manager", Description = "Branch Manager" },
                new Role { Id = 3, Name = "StoreKeeper", Description = "Warehouse Store Keeper" },
                new Role { Id = 4, Name = "Sales", Description = "Sales Staff" },
                new Role { Id = 5, Name = "HR", Description = "Human Resource" }
            );
        }
    }
}
