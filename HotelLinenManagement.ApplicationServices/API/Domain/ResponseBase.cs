using System;
using System.Collections.Generic;
using System.Text;

namespace HotelLinenManagement.ApplicationServices.API.Domain
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
    }
}
