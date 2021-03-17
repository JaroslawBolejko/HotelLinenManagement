using System;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class DocumentBase : EntityBase
    {

        public User User { get; set; }
        public Hotel Hotel { get; set; }
        [Required]
        [MaxLength(100)]
        public string DocumentName { get; set; }
        [Required]
        public int DocumentNumber { get; set; }
        [Required]
        public DateTime DocumentDate { get; set; }

    }
}
