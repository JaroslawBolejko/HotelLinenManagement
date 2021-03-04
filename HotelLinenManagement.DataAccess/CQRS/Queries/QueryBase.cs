using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(HotelLinenWarehouseContext context);
    }
}
