using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrinterManagement.Models
{
    public class Printer : BaseObject
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public PrinterType PrinterType { get; set; }
        public string Serial { get; set; }

        public Location Location { get; set; }

        public int LocationId { get; set; }

        public List<Maintenance> MyProperty { get; set; }
    }
}
