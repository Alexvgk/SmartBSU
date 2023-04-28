using Android.App;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBSU.Services.Data
{
    public class UserContext : DbContext
    {
        public DbSet<Models.Person> Persons { get; set; } = null!;

        public UserContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=128.140.32.175;user=bsuuser;password=bsuuser;database=smartBSU;",
                new MySqlServerVersion(new Version(8, 0, 28)));
        }
    }
}
