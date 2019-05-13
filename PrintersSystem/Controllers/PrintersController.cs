using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrinterManagement.Models;
using PrintersSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PrintersSystem
{
    public class PrintersController : Controller
    {
        private readonly PrintersSystemContext _context;

        public PrintersController(PrintersSystemContext context)
        {
            _context = context;
        }

        // GET: Printers
        public async Task<IActionResult> Index()
        {
            var printersSystemContext = _context.Printer.Include(p => p.Location);
            return View(await printersSystemContext.ToListAsync());
        }

        // GET: Printers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var printer = await _context.Printer
                .Include(p => p.Location)
                .Include(m => m.Maintances)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(printer);
        }

        // GET: Printers/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id");
            return View();
        }

        // POST: Printers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,PrinterType,Serial,PersonInCharge,LocationId,Id,Name")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(printer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", printer.LocationId);
            return View(printer);
        }

        // GET: Printers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var printer = await _context.Printer.FindAsync(id);
            if (printer == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", printer.LocationId);
            return View(printer);
        }

        // POST: Printers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Brand,Model,PrinterType,Serial,PersonInCharge,LocationId,Id,Name")] Printer printer)
        {
            if (id != printer.Id)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(printer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrinterExists(printer.Id))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", printer.LocationId);
            return View(printer);
        }

        // GET: Printers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var printer = await _context.Printer
                .Include(p => p.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(printer);
        }

        // POST: Printers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var printer = await _context.Printer.FindAsync(id);
            _context.Printer.Remove(printer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrinterExists(int id)
        {
            return _context.Printer.Any(e => e.Id == id);
        }
    }
}
