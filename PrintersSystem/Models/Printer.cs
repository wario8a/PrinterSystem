using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrinterManagement.Models
{
    public class Printer : BaseObject
    {
        [Required]
        [MaxLength(20)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        public PrinterType PrinterType { get; set; }
        [Required]
        [MaxLength(20)]
        public string Serial { get; set; }

        public string PersonInCharge { get; set; }

        public virtual Location Location { get; set; }

        public virtual int LocationId { get; set; }

        public virtual ICollection<Maintenance> Maintances { get; set; }
    }
}
