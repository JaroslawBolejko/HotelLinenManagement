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
    [Migration("20210302085807_TyposCorrectionInLinenTypes2")]
    partial class TyposCorrectionInLinenTypes2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("StoreroomId");

                    b.HasIndex("UserId");

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

                    b.Property<int?>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("StoreroomId");

                    b.HasIndex("UserId");

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

                    b.Property<string>("Color")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

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

                    b.Property<string>("Size")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

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

                    b.Property<int?>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<decimal>("InvoiceTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("StoreroomId");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LinenType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<string>("LinenTypeName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("StoreroomId");

                    b.ToTable("LinenTypes");
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

                    b.Property<int?>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("StoreroomId");

                    b.HasIndex("UserId");

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

                    b.Property<string>("StoreroomName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Storerooms");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StoreroomUser", b =>
                {
                    b.Property<int>("StoreroomsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("StoreroomsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("StoreroomUser");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsIssuedNote", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("HotelId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("HotelLinenId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", "Storeroom")
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("StoreroomId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.User", "User")
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("HotelLinen");

                    b.Navigation("Storeroom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsReceivedNote", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("HotelId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("HotelLinenId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", "Storeroom")
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("StoreroomId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.User", "User")
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("HotelLinen");

                    b.Navigation("Storeroom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.HotelLinen", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

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

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("Invoices")
                        .HasForeignKey("HotelLinenId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", "Storeroom")
                        .WithMany("Invoices")
                        .HasForeignKey("StoreroomId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.User", "User")
                        .WithMany("Invoices")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("HotelLinen");

                    b.Navigation("Storeroom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LinenType", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("LinenTypes")
                        .HasForeignKey("HotelLinenId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", null)
                        .WithMany("LinenTypes")
                        .HasForeignKey("StoreroomId");

                    b.Navigation("HotelLinen");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LiquidationDocument", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("LiquidationDocuments")
                        .HasForeignKey("HotelId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("LiquidationDocuments")
                        .HasForeignKey("HotelLinenId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", "Storeroom")
                        .WithMany("LiquidationDocuments")
                        .HasForeignKey("StoreroomId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.User", "User")
                        .WithMany("LiquidationDocuments")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("HotelLinen");

                    b.Navigation("Storeroom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Storeroom", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("Storerooms")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("StoreroomUser", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", null)
                        .WithMany()
                        .HasForeignKey("StoreroomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.Navigation("GoodsIssuedNotes");

                    b.Navigation("GoodsReceivedNotes");

                    b.Navigation("Invoices");

                    b.Navigation("LinenTypes");

                    b.Navigation("LiquidationDocuments");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Storeroom", b =>
                {
                    b.Navigation("GoodsIssuedNotes");

                    b.Navigation("GoodsReceivedNotes");

                    b.Navigation("HotelLinens");

                    b.Navigation("Invoices");

                    b.Navigation("LinenTypes");

                    b.Navigation("LiquidationDocuments");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.User", b =>
                {
                    b.Navigation("GoodsIssuedNotes");

                    b.Navigation("GoodsReceivedNotes");

                    b.Navigation("Invoices");

                    b.Navigation("LiquidationDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
