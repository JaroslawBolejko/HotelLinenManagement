﻿using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLinenManagement.DataAccess
{
    public class HotelLinenWarehouseContext : DbContext
    {
        public HotelLinenWarehouseContext(DbContextOptions<HotelLinenWarehouseContext> opt) : base(opt)
        {
        }

        public DbSet<HotelLinen> HotelLinens { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Invoice> Invices { get; set; }
        public DbSet<Storeroom> Storerooms { get; set; }
        public DbSet<LinienType> LinienTypes { get; set; }
    }
}
