using HotelLinenManagement.DataAccess.CQRS.Queries;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
