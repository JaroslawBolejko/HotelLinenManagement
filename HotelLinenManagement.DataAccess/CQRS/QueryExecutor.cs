using HotelLinenManagement.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly HotelLinenWarehouseContext context;

        public QueryExecutor(HotelLinenWarehouseContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
           return query.Execute(this.context);
        }
    }
}
