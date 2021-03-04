using HotelLinenManagement.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly HotelLinenWarehouseContext context;

        public CommandExecutor(HotelLinenWarehouseContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(this.context);   
        }
    }
}
