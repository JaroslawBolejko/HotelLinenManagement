using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.Components.GetGusDataAPIByTaxNumber
{
    public interface IGUSDataConnector
    {
        Task<T> szukajPodmioty<T>(string nip);

    }
}
