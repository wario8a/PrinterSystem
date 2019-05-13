using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrinterManagement.Models
{
    public class BaseObject
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }

        public BaseObject()
        {

        }
    }
}
