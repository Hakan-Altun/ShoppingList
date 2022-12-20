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
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(pk => pk.ProductDetailId);

            
            builder.Property(a => a.ProductName)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("nvarchar(40)");
            builder.Property(a => a.CategoryName)
                .HasMaxLength(40)
                .HasColumnType("nvarchar(40)");
            builder.Property(a => a.Quantity)
                .HasMaxLength(30)
                .HasColumnType("nvarchar(30)");
            builder.Property(a => a.Brand)
                .HasMaxLength(25)
                .HasColumnType("nvarchar(25)");
            builder.HasOne<Product>(a => a.Product)
                   .WithOne(a => a.ProductDetail)
                   .HasForeignKey<Product>(a => a.ProductDetailId);
        }
    }
}
