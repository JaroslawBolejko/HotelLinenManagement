using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelLinenManagement.DataAccess
{
    public class HotelLinenWarehouseContextFactory : IDesignTimeDbContextFactory<HotelLinenWarehouseContext>
    {
        public HotelLinenWarehouseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelLinenWarehouseContext>();
            optionsBuilder.UseSqlServer("Data Source=DELL;Initial Catalog=HotelLinenWarehouse;Integrated Security=True");
            
            return new HotelLinenWarehouseContext(optionsBuilder.Options);
        }
    }
}
