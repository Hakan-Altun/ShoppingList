using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(pk => pk.ProductId);
            builder.HasIndex(a => a.ProductName).IsUnique();
            builder.Property(a => a.ProductName).IsRequired()
                .HasMaxLength(40)
                .HasColumnType("nvarchar(40)");
            builder.Property(a => a.ProductImage).HasColumnType("nvarchar(max)");
            builder.Property(a => a.CategoryName).HasColumnType("nvarchar(40)");
            builder.Ignore(a => a.ImageFile);
            builder.HasOne(a => a.ProductDetail)
                   .WithOne(a => a.Product)
                   .HasForeignKey<ProductDetail>(a => a.ProductDetailId);
            
                   
        }
    }
}
