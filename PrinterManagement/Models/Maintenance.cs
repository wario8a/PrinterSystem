using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrinterManagement.Models
{
    public class Maintenance : BaseObject
    {
        public DateTime Date { get; set; }

        public string Technician { get; set; }

        public Printer Printer { get; set; }

        public int PrinterId { get; set; }
    }
}
