﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace SmartBSU.Services.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
       //     builder.HasOne(u => u.RegCode)
               // .WithOne(r => r.User)
              //  .HasForeignKey<User>(u => u.IdRegCode);
            //builder.HasOne(u => u)
               // .WithOne(r => r.User)
             //   .HasForeignKey<User>(u => u.IdPassword);
        }
    }
}