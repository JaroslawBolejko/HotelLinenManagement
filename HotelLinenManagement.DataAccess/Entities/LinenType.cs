using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class LinenType : EntityBase
    {
        public HotelLinen HotelLinen { get; set; }

        [Required]
        [MaxLength(250)]
        public string LinenTypeName { get; set; }
    }
}
