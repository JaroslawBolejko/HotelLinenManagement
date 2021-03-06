﻿using HotelLinenManagement.DataAccess.Entities;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.CQRS.Commands.Users
{
    public class DeleteUserByIdCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(HotelLinenWarehouseContext context)
        {
            context.ChangeTracker.Clear();
            context.Users.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;

        }
    }
}
