using HotelLinenManagement.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameter,TResult>(CommandBase<TParameter,TResult> command);
    }
}
