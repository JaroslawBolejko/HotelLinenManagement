using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.Components.GetGusDataAPIByTaxNumber
{
    public interface IGUSDataConnector
    {
        Task<T> szukajPodmioty<T>(string nip);

    }
}
