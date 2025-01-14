﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(pk => pk.CategoryId);

            builder.HasIndex(a => a.CategoryName).IsUnique();
            builder.Property(a => a.CategoryName)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("nvarchar(40)");
        }
    }
}
