namespace HotelLinenManagement.ApplicationServices.Components.PassworHasher
{
    public interface IPasswordHasher
    {
        public string[] Hash(string password);
        public string HashToCheck(string password, string hashedSalt);
    }
}
