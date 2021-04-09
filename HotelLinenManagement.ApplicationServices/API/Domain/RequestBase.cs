namespace HotelLinenManagement.ApplicationServices.API.Domain
{
    public enum AppRole
    {
        AdminHotel,
        UserHotel,
        UserLaundry,

    }
   public class RequestBase
    {
        public int AuthenticationId { get; set; }
        public string AuthenticationName { get; set; }
        public AppRole AuthenticationRole { get; set; }
    }
}
