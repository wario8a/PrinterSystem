using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PrinterManagement.Models
{
    public class PrinterManagementContext : DbContext
    {
        public PrinterManagementContext (DbContextOptions<PrinterManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Printer> Printers { get; set; }
    }
}
