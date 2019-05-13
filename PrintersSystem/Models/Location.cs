using System.Collections.Generic;

namespace PrinterManagement.Models
{
    public class Location : BaseObject
    {
        public virtual ICollection<Printer> Printers { get; set; }

    }
}
