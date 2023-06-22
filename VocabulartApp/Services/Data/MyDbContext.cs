using Android.App;
using Android.Content;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SmartBSU.Services.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> users { get; set; } = null!;
        public DbSet<RegCode> RegistCodes { get; set; } = null!;

        public MyDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                  .HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnType("char(36)");
            modelBuilder.Entity<RegCode>()
        .HasKey(r => r.Id);
            modelBuilder.Entity<RegCode>().Property(x => x.Id).HasColumnType("char(36)");
            modelBuilder.Entity<UID>()
        .HasKey(r => r.Id);
            modelBuilder.Entity<UID>().Property(x => x.Id).HasColumnType("char(36)");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          // optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString,
           //     new MySqlServerVersion(new Version(8, 0, 28)));
            optionsBuilder.UseMySql("server=128.140.32.175;user=bsuuser;password=bsuuser;database=smartBSU;",
    new MySqlServerVersion(new Version(8, 0, 28)));
        }
    }
}
