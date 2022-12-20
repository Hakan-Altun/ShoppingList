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
    public class ListProductConfiguration : IEntityTypeConfiguration<ListProduct>
    {
        public void Configure(EntityTypeBuilder<ListProduct> builder)
        {
            builder.HasKey(a => new { a.ProductId, a.ListId });
            builder.HasOne(a => a.Product)
                   .WithMany(a => a.ListProducts)
                   .HasForeignKey(a => a.ProductId);
            builder.HasOne(a => a.List)
                   .WithMany(a => a.ListProducts)
                   .HasForeignKey(a => a.ListId);
        }
    }
}
