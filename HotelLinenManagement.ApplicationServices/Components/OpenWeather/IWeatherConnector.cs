using System.Threading.Tasks;

namespace HotelLinenManagement.ApplicationServices.Components.OpenWeather
{
    interface IWeatherConnector
    {
        Task<Weather> Fetch(string City);

    }
}
