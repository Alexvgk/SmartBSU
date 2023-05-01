using Android.App;
using Android.Content;
using Microsoft.EntityFrameworkCore;
using SmartBSU.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBSU.Services.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Models.User> users { get; set; } = null!;
        public DbSet<RegCode> RegistCodes { get; set; } = null!;

        public MyDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegCode>()
        .HasKey(r => r.IdRegistCode);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=128.140.32.175;user=bsuuser;password=bsuuser;database=smartBSU;",
                new MySqlServerVersion(new Version(8, 0, 28)));

        }
    }
}
