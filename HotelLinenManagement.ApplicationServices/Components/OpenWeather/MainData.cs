using Newtonsoft.Json;

namespace HotelLinenManagement.ApplicationServices.Components.OpenWeather
{
    public class MainData
    {
        [JsonProperty("temp")]
        public double Temerature { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
    }
}
