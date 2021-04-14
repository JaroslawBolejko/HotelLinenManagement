using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [Required]
        public int StoreroomId { get; set; }
        public Storeroom Storeroom { get; set; }

        public List<LinenType> LinienTypes { get; set; }

        public List<Laundry> Laundries { get; set; }

        [Required]
        [MaxLength(250)]
        public string LinenName { get; set; }

        [Required]
        public int LinenAmount { get; set; }
        [MaxLength(250)]
        public string LinenTypeName { get; set; }
        [MaxLength(250)]
        public string Size { get; set; }
        [MaxLength(250)]
        public string Color { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public double LinienWeight { get; set; }

    }
}
