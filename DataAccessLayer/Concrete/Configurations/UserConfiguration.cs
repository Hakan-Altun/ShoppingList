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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(pk => pk.UserId);

            builder.HasIndex(a => a.UserEmail).IsUnique();
            builder.Property(a => a.UserEmail)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("nvarchar(40)");
            builder.Property(a => a.UserName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnType("nvarchar(25)");
            builder.Property(a => a.UserLastName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnType("nvarchar(25)");
            builder.Property(a => a.UserPassword)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");
            builder.Ignore(a => a.ConfirmPassword);
        }
    }
}
