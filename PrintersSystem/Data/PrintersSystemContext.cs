using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrinterManagement.Models;

namespace PrintersSystem.Models
{
    public class PrintersSystemContext : DbContext
    {
        public PrintersSystemContext (DbContextOptions<PrintersSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Printer> Printer { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Maintenance> Maintenance { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var listLocations = loadPrinters();
            var listPrinters = loadPrinters(listLocations);
            var listMaintenances = loadMaintenances(listPrinters);
            modelBuilder.Entity<Location>().HasData(listLocations.ToArray());
            modelBuilder.Entity<Printer>().HasData(listPrinters.ToArray());
            modelBuilder.Entity<Maintenance>().HasData(listMaintenances.ToArray());
        }

        private static List<Location> loadPrinters()
        {
            return new List<Location> { new Location { Id = 1, Name = "Recepcion" }, new Location { Id = 2, Name = "Sala de juntas" }, new Location { Id = 3, Name = "Gerencia" }, new Location { Id = 4, Name = "Facturacion" }, new Location { Id = 5, Name = "Contabilidad" } };
        }

        private List<Maintenance> loadMaintenances(List<Printer> listPrinters)
        {
            List<Maintenance> listMaintenance = new List<Maintenance>();
            int Idcount = 1;

            foreach (var item in listPrinters)
            {
                listMaintenance.Add(new Maintenance { Id = Idcount, Date = DateTime.Now.AddDays(new Random().Next(20)), LocationId = item.LocationId, Name = "Cambio Tinta" + Idcount, PrinterId = item.Id, Technician="John Snow",  });
                Idcount++;
                listMaintenance.Add(new Maintenance { Id = Idcount, Date = DateTime.Now.AddDays(new Random().Next(20)), LocationId = item.LocationId, Name = "Limpieza" + Idcount, PrinterId = item.Id, Technician = "Cersei", });
                Idcount++;
                listMaintenance.Add(new Maintenance { Id = Idcount, Date = DateTime.Now.AddDays(new Random().Next(20)), LocationId = item.LocationId, Name = "Calibracion" + Idcount, PrinterId = item.Id, Technician = "Dayneris", });
                Idcount++;
            }

            return listMaintenance;
        }

        private List<Printer> loadPrinters(List<Location> listLocations)
        {
            List<Printer> listPrinters = new List<Printer>();
            int Idcount = 1;

            foreach (var item in listLocations)
            {
                listPrinters.Add(new Printer { Id = Idcount, LocationId = item.Id, Brand = "Epson", Model = "2010", Name = "Printer" + Idcount, PrinterType = PrinterType.Other, Serial = "01021", PersonInCharge = "Arya" });
                Idcount++;
                listPrinters.Add(new Printer { Id = Idcount, LocationId = item.Id, Brand = "Sony", Model = "2011", Name = "Printer" + Idcount, PrinterType = PrinterType.Ink, Serial = "01021", PersonInCharge = "Samsa" });
                Idcount++;
                listPrinters.Add(new Printer { Id = Idcount, LocationId = item.Id, Brand = "HP", Model = "2012", Name = "Printer" + Idcount, PrinterType = PrinterType.Laser, Serial = "01021", PersonInCharge = "Ricon" });
                Idcount++;
                listPrinters.Add(new Printer { Id = Idcount, LocationId = item.Id, Brand = "Dell", Model = "2013", Name = "Printer" + Idcount, PrinterType = PrinterType.Point, Serial = "01021", PersonInCharge = "Robb" });
                Idcount++;
                listPrinters.Add(new Printer { Id = Idcount, LocationId = item.Id, Brand = "Ricon", Model = "2014", Name = "Printer" + Idcount, PrinterType = PrinterType.Other, Serial = "01021", PersonInCharge = "Bran" });
                Idcount++;
            }

            return listPrinters;
        }
    }
}
