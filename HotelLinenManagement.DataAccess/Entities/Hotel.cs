using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLinenManagement.DataAccess.Entities
{
   public class Hotel : EntityBase 
    {
        [Required]
        [MaxLength(250)]
        public string HotelName { get; set; }

    
        public List<Storeroom> Storerooms { get; set; }

    }
}
