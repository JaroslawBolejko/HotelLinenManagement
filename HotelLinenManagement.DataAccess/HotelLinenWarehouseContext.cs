using HotelLinenManagement.DataAccess.Entities;
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
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Storeroom> Storerooms { get; set; }
        public DbSet<LinenType> LinenTypes { get; set; }
        public DbSet<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public DbSet<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public DbSet<LiquidationDocument> LiquidationDocuments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Laundry> Laundries { get; set; }
     
    }
}
