﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ShoppingListContext))]
    [Migration("20221218202121_sec")]
    partial class sec
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.List", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListId"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ListId");

                    b.HasIndex("ListName")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("Entities.ListProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<bool>("ProductStatus")
                        .HasColumnType("bit");

                    b.HasKey("ProductId", "ListId");

                    b.HasIndex("ListId");

                    b.ToTable("ListProducts");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ListId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductDetailId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("ProductStatus")
                        .HasColumnType("bit");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductDetailId")
                        .IsUnique()
                        .HasFilter("[ProductDetailId] IS NOT NULL");

                    b.HasIndex("ProductName")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.ProductDetail", b =>
                {
                    b.Property<int>("ProductDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductDetailId"), 1L, 1);

                    b.Property<string>("Brand")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Quantity")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProductDetailId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserEmail")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.List", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("Lists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.ListProduct", b =>
                {
                    b.HasOne("Entities.List", "List")
                        .WithMany("ListProducts")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Product", "Product")
                        .WithMany("ListProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Entities.ProductDetail", "ProductDetail")
                        .WithOne("Product")
                        .HasForeignKey("Entities.Product", "ProductDetailId");

                    b.Navigation("Category");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.HasOne("Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.List", b =>
                {
                    b.Navigation("ListProducts");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Navigation("ListProducts");
                });

            modelBuilder.Entity("Entities.ProductDetail", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("Lists");
                });
#pragma warning restore 612, 618
        }
    }
}
