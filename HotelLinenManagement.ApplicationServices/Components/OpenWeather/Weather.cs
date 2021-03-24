using Newtonsoft.Json;

namespace HotelLinenManagement.ApplicationServices.Components.OpenWeather
{
    public class Weather
    {
        [JsonProperty("main")]
        public MainData Main{ get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
