﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week6SampleCode;

#nullable disable

namespace Week6SampleCode.Data.BusinessModelMigrations
{
    [DbContext(typeof(BusinessContext))]
    [Migration("20231023173923_Initial-Business-Model")]
    partial class InitialBusinessModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductModel.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Description = "Hardware"
                        },
                        new
                        {
                            CategoryID = 2,
                            Description = "Electrical Appliances"
                        });
                });

            modelBuilder.Entity("ProductModel.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.Property<DateTime>("dateFirstIssued")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            Description = "9 inch nails",
                            QuantityInStock = 200,
                            UnitPrice = 0.1f,
                            dateFirstIssued = new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 1,
                            Description = "9 inch bolts",
                            QuantityInStock = 120,
                            UnitPrice = 0.2f,
                            dateFirstIssued = new DateTime(2019, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 2,
                            Description = "Chimney Hoover",
                            QuantityInStock = 10,
                            UnitPrice = 100.5f,
                            dateFirstIssued = new DateTime(2019, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryID = 2,
                            Description = "Wassing Machine",
                            QuantityInStock = 7,
                            UnitPrice = 399.99f,
                            dateFirstIssued = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ProductModel.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("SupplierAddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierAddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierID = 1,
                            SupplierAddressLine1 = "The Coop",
                            SupplierAddressLine2 = "Copersville",
                            SupplierName = "Joe bloggs"
                        },
                        new
                        {
                            SupplierID = 2,
                            SupplierAddressLine1 = "Priory Road",
                            SupplierAddressLine2 = "Paris",
                            SupplierName = "Mary Quant"
                        });
                });

            modelBuilder.Entity("ProductModel.SupplierProduct", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFirstSupplied")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductID", "SupplierID");

                    b.HasIndex("SupplierID");

                    b.ToTable("SupplierProducts");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            SupplierID = 1,
                            DateFirstSupplied = new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 2,
                            SupplierID = 1,
                            DateFirstSupplied = new DateTime(2019, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 3,
                            SupplierID = 2,
                            DateFirstSupplied = new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 4,
                            SupplierID = 2,
                            DateFirstSupplied = new DateTime(2019, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ProductModel.Product", b =>
                {
                    b.HasOne("ProductModel.Category", "associatedCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("associatedCategory");
                });

            modelBuilder.Entity("ProductModel.SupplierProduct", b =>
                {
                    b.HasOne("ProductModel.Product", "FK_Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductModel.Supplier", "FK_Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Product");

                    b.Navigation("FK_Supplier");
                });

            modelBuilder.Entity("ProductModel.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
