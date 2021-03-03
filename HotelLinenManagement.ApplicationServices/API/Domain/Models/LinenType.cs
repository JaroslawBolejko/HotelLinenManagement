namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class LinenType
    {
        public string Id { get; set; }
        public string LinenTypeName { get; set; }
        public HotelLinen HotelLinen { get; set; }
    }
}
