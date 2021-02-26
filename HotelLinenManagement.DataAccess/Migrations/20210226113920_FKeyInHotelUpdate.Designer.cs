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
    [Migration("20210226113920_FKeyInHotelUpdate")]
    partial class FKeyInHotelUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("StoreroomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

                    b.Property<int?>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InviceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("InvoiceTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HotelLinenId");

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

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.HotelLinen", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Storeroom", null)
                        .WithMany("HotelLinens")
                        .HasForeignKey("StoreroomId");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Invoice", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("Invices")
                        .HasForeignKey("HotelLinenId");

                    b.Navigation("HotelLinen");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.LinienType", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("LinienTypes")
                        .HasForeignKey("HotelLinenId");

                    b.Navigation("HotelLinen");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Storeroom", b =>
                {
                    b.HasOne("HotelLinenManagement.DataAccess.Entities.Hotel", "Hotel")
                        .WithMany("Storerooms")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Hotel", b =>
                {
                    b.Navigation("Storerooms");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Navigation("Invices");

                    b.Navigation("LinienTypes");
                });

            modelBuilder.Entity("HotelLinenManagement.DataAccess.Entities.Storeroom", b =>
                {
                    b.Navigation("HotelLinens");
                });
#pragma warning restore 612, 618
        }
    }
}
