using HotelLinenManagement.DataAccess.Entities;
using System.Collections.Generic;

namespace HotelLinenManagement.DataAccess
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);


    }
}
