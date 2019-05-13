using System;
using System.ComponentModel.DataAnnotations;

namespace PrinterManagement.Models
{
    public class Maintenance : BaseObject
    {
        [Required]
        //[MaxLength(20)]
        //[DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(40)]
        public string Technician { get; set; }

        [Required]
        public Printer Printer { get; set; }

        public virtual int PrinterId { get; set; }

        public virtual Location Location { get; set; }

        public virtual int LocationId { get; set; }

    }
}
