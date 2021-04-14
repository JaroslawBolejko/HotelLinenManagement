using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelLinenManagement.DataAccess
{
    public class HotelLinenWarehouseContextFactory : IDesignTimeDbContextFactory<HotelLinenWarehouseContext>
    {
        public HotelLinenWarehouseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelLinenWarehouseContext>();
            optionsBuilder.UseSqlServer("Server=tcp:hotellinen.database.windows.net,1433;Initial Catalog=HotelLinenWarehauseStorage;Persist Security Info=False;User ID=jarokm;Password=Kravmaga85;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            
            return new HotelLinenWarehouseContext(optionsBuilder.Options);
        }
    }
}
