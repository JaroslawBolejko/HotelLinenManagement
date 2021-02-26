using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLinenManagement.DataAccess.Entities
{
    public class HotelLinen : EntityBase
    {
        //HotelId to wskaznie po czym ma się łączyć z z inna tabelą w relacji, jak nie określimy tego klucza
        //to entity zrobi to za nas
   

        public List<Invoice> Invices { get; set; }
        public List<LinienType> LinienTypes { get; set; }

        [Required]
        [MaxLength(250)]
        public string LinenName { get; set; }
        [Required]
        [MaxLength(250)]
        public string LinenType { get; set; }
        public int LinenAmount { get; set; }
        public double LinienWeight { get; set; }

    }
}
