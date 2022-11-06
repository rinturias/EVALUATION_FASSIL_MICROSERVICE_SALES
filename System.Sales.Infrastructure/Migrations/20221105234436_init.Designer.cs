﻿// <auto-generated />
using System;
using System.Sales.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace System.Sales.Infrastructure.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20221105234436_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("System.Sales.Infrastructure.EF.ReadModel.DetailSaleReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("date")
                        .HasColumnType("DateTime")
                        .HasColumnName("date");

                    b.Property<decimal>("price")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("price");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("productId");

                    b.Property<int>("quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.ToTable("DetailSale", (string)null);
                });

            modelBuilder.Entity("System.Sales.Infrastructure.EF.ReadModel.SaleReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("active")
                        .HasColumnType("int")
                        .HasColumnName("active");

                    b.Property<decimal>("amountNominal")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("amountNominal");

                    b.Property<decimal>("amountTotal")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("amountTotal");

                    b.Property<Guid>("clienteId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("clienteId");

                    b.Property<DateTime>("date")
                        .HasColumnType("DateTime")
                        .HasColumnName("date");

                    b.Property<decimal>("discount")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("discount");

                    b.Property<decimal>("iva")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("iva");

                    b.Property<string>("note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("note");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("System.Sales.Infrastructure.EF.ReadModel.DetailSaleReadModel", b =>
                {
                    b.HasOne("System.Sales.Infrastructure.EF.ReadModel.SaleReadModel", "Sale")
                        .WithMany("detailSale")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("System.Sales.Infrastructure.EF.ReadModel.SaleReadModel", b =>
                {
                    b.Navigation("detailSale");
                });
#pragma warning restore 612, 618
        }
    }
}
