using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataContext:DbContext
    {
       
            public DataContext(DbContextOptions<DataContext> options)
                : base(options)
            {
            }

            public DbSet<User> Users { get; set; }
            public DbSet<Role> UserRoles { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Seed UserRoles
                modelBuilder.Entity<Role>().HasData(
                    new Role { Id = 1, RoleName = "Admin" },
                    new Role { Id = 2, RoleName = "User" }
                );
            }
        
    }
}
