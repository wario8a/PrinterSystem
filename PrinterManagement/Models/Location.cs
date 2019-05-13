using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrinterManagement.Models
{
    public class Location : BaseObject
    {
        public string InCharge { get; set; }

        public List<Printer> Printers { get; set; }

    }
}
