﻿// <auto-generated />
using System;
using HotelLinenManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelLinenManagement.DataAccess.Migrations
{
    [DbContext(typeof(HotelLinenWarehouseContext))]
    [Migration("20210301210829_AddGoodsIssuedAndLiquidationDocument")]
    partial class AddGoodsIssuedAndLiquidationDocument
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelLinenInvoice", b =>
                {
                    b.Property<int>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int>("InvicesId")
                        .HasColumnType("int");

                    b.HasKey("HotelLinenId", "InvicesId");

                    b.HasIndex("InvicesId");

                    b.ToTable("HotelLinenInvoice");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsIssuedNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("GoodsIssuedNotes");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsReceivedNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("GoodsReceivedNotes");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GoodsIssuedNoteId")
                        .HasColumnType("int");

                    b.Property<int?>("GoodsReceivedNoteId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("LinenAmount")
                        .HasColumnType("int");

                    b.Property<string>("LinenName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LinenType")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("LinienWeight")
                        .HasColumnType("float");

                    b.Property<int?>("LiquidationDocumentId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GoodsIssuedNoteId");

                    b.HasIndex("GoodsReceivedNoteId");

                    b.HasIndex("HotelId");

                    b.HasIndex("LiquidationDocumentId");

                    b.HasIndex("StoreroomId");

                    b.ToTable("HotelLinens");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<decimal>("InvoiceTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Invices");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LinienType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<string>("LinienTypeName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("HotelLinenId");

                    b.ToTable("LinienTypes");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LiquidationDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("LiquidationDocuments");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Storeroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReciptDate")
                        .HasMaxLength(250)
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("StoreRoomName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Storerooms");
                });

            modelBuilder.Entity("HotelLinenInvoice", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", null)
                        .WithMany()
                        .HasForeignKey("HotelLinenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsIssuedNote", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsReceivedNote", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.HotelLinen", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.GoodsIssuedNote", null)
                        .WithMany("HotelLinen")
                        .HasForeignKey("GoodsIssuedNoteId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.GoodsReceivedNote", null)
                        .WithMany("HotelLinen")
                        .HasForeignKey("GoodsReceivedNoteId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.LiquidationDocument", null)
                        .WithMany("HotelLinen")
                        .HasForeignKey("LiquidationDocumentId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", null)
                        .WithMany("HotelLinens")
                        .HasForeignKey("StoreroomId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Invoice", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("Invoices")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LinienType", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("LinienTypes")
                        .HasForeignKey("HotelLinenId");

                    b.Navigation("HotelLinen");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LiquidationDocument", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("LiquidationDocuments")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Storeroom", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("Storerooms")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsIssuedNote", b =>
                {
                    b.Navigation("HotelLinen");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsReceivedNote", b =>
                {
                    b.Navigation("HotelLinen");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Hotel", b =>
                {
                    b.Navigation("GoodsIssuedNotes");

                    b.Navigation("GoodsReceivedNotes");

                    b.Navigation("Invoices");

                    b.Navigation("LiquidationDocuments");

                    b.Navigation("Storerooms");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Navigation("LinienTypes");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LiquidationDocument", b =>
                {
                    b.Navigation("HotelLinen");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Storeroom", b =>
                {
                    b.Navigation("HotelLinens");
                });
#pragma warning restore 612, 618
        }
    }
}
