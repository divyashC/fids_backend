using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fids_backend.Models;

namespace fids_backend.Controllers
{
    public class FlightDetailsController : Controller
    {
        private readonly fidsContext _context;

        public FlightDetailsController(fidsContext context)
        {
            _context = context;
        }

        // GET: FlightDetails
        public async Task<IActionResult> Index()
        {
            return _context.FlightDetails != null ? 
                          View(await _context.FlightDetails.ToListAsync()) :
                          Problem("Entity set 'fidsContext.FlightDetails'  is null.");
        }

        // GET: FlightDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FlightDetails == null)
            {
                return NotFound();
            }

            var flightDetail = await _context.FlightDetails
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            return View(flightDetail);
        }

        // GET: FlightDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlightDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,FlightNo,Airline,Origin,OriginIata,DepartureTime,DepartureTerminal,Destination,DestinationIata,ArrivalTime,ArrivalTerminal,FlightDate,FlightDuration")] FlightDetail flightDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flightDetail);
        }

        // GET: FlightDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FlightDetails == null)
            {
                return NotFound();
            }

            var flightDetail = await _context.FlightDetails.FindAsync(id);
            if (flightDetail == null)
            {
                return NotFound();
            }
            return View(flightDetail);
        }

        // POST: FlightDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,FlightNo,Airline,Origin,OriginIata,DepartureTime,DepartureTerminal,Destination,DestinationIata,ArrivalTime,ArrivalTerminal,FlightDate,FlightDuration")] FlightDetail flightDetail)
        {
            if (id != flightDetail.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightDetailExists(flightDetail.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flightDetail);
        }

        // GET: FlightDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FlightDetails == null)
            {
                return NotFound();
            }

            var flightDetail = await _context.FlightDetails
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            return View(flightDetail);
        }

        // POST: FlightDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FlightDetails == null)
            {
                return Problem("Entity set 'fidsContext.FlightDetails'  is null.");
            }
            var flightDetail = await _context.FlightDetails.FindAsync(id);
            if (flightDetail != null)
            {
                _context.FlightDetails.Remove(flightDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightDetailExists(int id)
        {
          return (_context.FlightDetails?.Any(e => e.FlightId == id)).GetValueOrDefault();
        }
    }
}
