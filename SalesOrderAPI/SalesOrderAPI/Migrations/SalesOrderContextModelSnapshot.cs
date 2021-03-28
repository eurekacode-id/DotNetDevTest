﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesOrderAPI.Models;

namespace SalesOrderAPI.Migrations
{
    [DbContext(typeof(SalesOrderContext))]
    partial class SalesOrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SalesOrderAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompleteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesItem", b =>
                {
                    b.Property<int>("SalesItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalesItemId");

                    b.ToTable("SalesItems");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesItemPrice", b =>
                {
                    b.Property<int>("SalesItemPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SalesItemId")
                        .HasColumnType("int");

                    b.Property<int?>("UoMId")
                        .HasColumnType("int");

                    b.HasKey("SalesItemPriceId");

                    b.HasIndex("SalesItemId");

                    b.HasIndex("UoMId");

                    b.ToTable("SalesItemPrices");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesOrder", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("SalesOrderDocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalesOrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("SalesOrders");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesOrderLine", b =>
                {
                    b.Property<int>("SalesOrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("PriceAmount")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SalesItemPriceId")
                        .HasColumnType("int");

                    b.Property<int?>("SalesOrderId")
                        .HasColumnType("int");

                    b.HasKey("SalesOrderLineId");

                    b.HasIndex("SalesItemPriceId");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("SalesOrderLines");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.UoM", b =>
                {
                    b.Property<int>("UoMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UoMId");

                    b.ToTable("UoMs");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesItemPrice", b =>
                {
                    b.HasOne("SalesOrderAPI.Models.SalesItem", "SalesItem")
                        .WithMany("SalesItemPrices")
                        .HasForeignKey("SalesItemId");

                    b.HasOne("SalesOrderAPI.Models.UoM", "UoM")
                        .WithMany("SalesItemPrices")
                        .HasForeignKey("UoMId");

                    b.Navigation("SalesItem");

                    b.Navigation("UoM");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesOrder", b =>
                {
                    b.HasOne("SalesOrderAPI.Models.Customer", "Customer")
                        .WithMany("SalesOrders")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesOrderLine", b =>
                {
                    b.HasOne("SalesOrderAPI.Models.SalesItemPrice", "SalesItemPrice")
                        .WithMany("SalesOrderLines")
                        .HasForeignKey("SalesItemPriceId");

                    b.HasOne("SalesOrderAPI.Models.SalesOrder", "SalesOrder")
                        .WithMany("SalesOrderLines")
                        .HasForeignKey("SalesOrderId");

                    b.Navigation("SalesItemPrice");

                    b.Navigation("SalesOrder");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.Customer", b =>
                {
                    b.Navigation("SalesOrders");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesItem", b =>
                {
                    b.Navigation("SalesItemPrices");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesItemPrice", b =>
                {
                    b.Navigation("SalesOrderLines");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.SalesOrder", b =>
                {
                    b.Navigation("SalesOrderLines");
                });

            modelBuilder.Entity("SalesOrderAPI.Models.UoM", b =>
                {
                    b.Navigation("SalesItemPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
