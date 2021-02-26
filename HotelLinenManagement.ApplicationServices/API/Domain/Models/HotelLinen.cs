namespace HotelLinenManagement.ApplicationServices.API.Domain.Models
{
    public class HotelLinen
    {
        public int Id { get; set; }
        public string LinenName { get; set; }
       
        public string LinenType { get; set; }
        public int LinenAmount { get; set; }
        public double LinienWeight { get; set; }

    }
}
