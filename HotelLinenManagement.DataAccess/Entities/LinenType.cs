using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
