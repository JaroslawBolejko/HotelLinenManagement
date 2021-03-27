﻿// <auto-generated />
using System;
using HotelLinenManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelLinenManagement.DataAccess.Migrations
{
    [DbContext(typeof(HotelLinenWarehouseContext))]
    partial class HotelLinenWarehouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelLinenLaundry", b =>
                {
                    b.Property<int>("HotelLinensId")
                        .HasColumnType("int");

                    b.Property<int>("LaundriesId")
                        .HasColumnType("int");

                    b.HasKey("HotelLinensId", "LaundriesId");

                    b.HasIndex("LaundriesId");

                    b.ToTable("HotelLinenLaundry");
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("LaundryId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("LaundryId");

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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("LaundryId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("LaundryId");

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

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

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

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("LinenAmount")
                        .HasColumnType("int");

                    b.Property<string>("LinenName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LinenTypeName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("LinienWeight")
                        .HasColumnType("float");

                    b.Property<string>("Size")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("StoreroomId")
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
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<double>("InvoiceTotal")
                        .HasColumnType("float");

                    b.Property<int>("LaundryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("LaundryId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Laundry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("ReciptDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Laundries");
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DocumentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Workplace")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

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

            modelBuilder.Entity("HotelLinenLaundry", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", null)
                        .WithMany()
                        .HasForeignKey("HotelLinensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Laundry", null)
                        .WithMany()
                        .HasForeignKey("LaundriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsIssuedNote", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("HotelId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Laundry", null)
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("LaundryId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", null)
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("StoreroomId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.User", "User")
                        .WithMany("GoodsIssuedNotes")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.GoodsReceivedNote", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("HotelId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Laundry", null)
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("LaundryId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", null)
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("StoreroomId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.User", "User")
                        .WithMany("GoodsReceivedNotes")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.HotelLinen", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("HotelLinens")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", "Storeroom")
                        .WithMany("HotelLinens")
                        .HasForeignKey("StoreroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Storeroom");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Invoice", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("Invoices")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Laundry", "Laundry")
                        .WithMany("Invoices")
                        .HasForeignKey("LaundryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Laundry");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LinenType", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("LinienTypes")
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

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", null)
                        .WithMany("LiquidationDocuments")
                        .HasForeignKey("StoreroomId");

                    b.HasOne("HotelLinenManagement.DataAccess.Entities.User", "User")
                        .WithMany("LiquidationDocuments")
                        .HasForeignKey("UserId");

                    b.Navigation("Hotel");

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

                    b.Navigation("HotelLinens");

                    b.Navigation("Invoices");

                    b.Navigation("LiquidationDocuments");

                    b.Navigation("Storerooms");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Navigation("LinienTypes");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Laundry", b =>
                {
                    b.Navigation("GoodsIssuedNotes");

                    b.Navigation("GoodsReceivedNotes");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Storeroom", b =>
                {
                    b.Navigation("GoodsIssuedNotes");

                    b.Navigation("GoodsReceivedNotes");

                    b.Navigation("HotelLinens");

                    b.Navigation("LinenTypes");

                    b.Navigation("LiquidationDocuments");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.User", b =>
                {
                    b.Navigation("GoodsIssuedNotes");

                    b.Navigation("GoodsReceivedNotes");

                    b.Navigation("LiquidationDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
