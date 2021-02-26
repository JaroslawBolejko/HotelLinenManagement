using HotelLinenManagement.DataAccess;
using HotelLinenManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelLinenManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HLStoreroomController
    {
        private readonly IRepository<Storeroom> storeroomRepository;
        public HLStoreroomController(IRepository<Storeroom> storeroomRepository)
        {
            this.storeroomRepository = storeroomRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Storeroom> GetAllHotelLinens() => this.storeroomRepository.GetAll();
       
        [HttpGet]
        [Route("{storeroomId}")]
        public Storeroom GetHotelLinenById(int storeroomId) => this.storeroomRepository.GetById(storeroomId);
    }
}
