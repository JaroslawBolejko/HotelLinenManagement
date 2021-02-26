using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class LinienType : EntityBase
    {
        public HotelLinen HotelLinen { get; set; }

        [Required]
        [MaxLength(250)]
        public string LinienTypeName { get; set; }
    }
}
