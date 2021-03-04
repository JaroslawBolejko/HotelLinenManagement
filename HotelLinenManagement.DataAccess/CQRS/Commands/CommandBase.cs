using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParameter, TResult>
    {
        public TParameter Parameter {get;set;}
    public abstract Task<TResult> Execute(HotelLinenWarehouseContext context);
    }
}
