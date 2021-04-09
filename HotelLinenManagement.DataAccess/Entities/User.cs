using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{

    public enum Role
    {
        AdminHotel,
        UserHotel,
        UserLaundry

    }
    public class User : EntityBase
    {
        public List<Storeroom> Storerooms { get; set; }
        public List<GoodsReceivedNote> GoodsReceivedNotes { get; set; }
        public List<GoodsIssuedNote> GoodsIssuedNotes { get; set; }
        public List<LiquidationDocument> LiquidationDocuments { get; set; }
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Position { get; set; }
        [Required]
        [MaxLength(250)]
        public string Workplace { get; set; }
        [Required]
        public Role Permission { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Salt { get; set; }


    }
}
