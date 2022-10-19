using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fids_backend.Models;

namespace fids_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightAPIController : ControllerBase
    {
        private readonly fidsContext _context;

        public FlightAPIController(fidsContext context)
        {
            _context = context;
        }
        
        // GET: api/FlightAPI/search/{search}
        [HttpGet("search/{search}")]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetFlight(string search)
        {
            var flight = await _context.FlightDetails.Where(f => f.Origin.Contains(search) || f.Destination.Contains(search)).ToListAsync();

            if (flight == null)
            {
                return NotFound();
            }
            
            var dataSetA = new List<FlightDetail>(); // flight after today
            var dataSetB = new List<FlightDetail>(); // today's flight

            foreach (var f in flight)
            {
                if (f.FlightDate >= DateTime.Now)
                {
                    dataSetA.Add(f);
                }
            }
          
            foreach (var f in flight)
            {
                if (f.DepartureTime.Add(new TimeSpan(0, 30, 0)) < DateTime.Now.TimeOfDay) 
                { 
                    continue;
                } 
                dataSetB.Add(f);
            }
          
            dataSetB.AddRange(dataSetA);
            dataSetB = dataSetB.OrderBy(f => f.FlightDate).ToList();
            
            return dataSetB;
        }
        
        // GET: api/FlightAPI/search/past/{search}
        [HttpGet("search/past/{search}")]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetPastFlight(string search)
        {
            var flight = await _context.FlightDetails.Where(f => f.Origin.Contains(search) || f.Destination.Contains(search)).ToListAsync();

            if (flight == null)
            {
                return NotFound();
            }
            
            var dataSet = new List<FlightDetail>(); // old flights

            foreach (var item in flight)
            {
                if (item.FlightDate < DateTime.Now && item.FlightDate.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    dataSet.Add(item);
                }
            }
            
            return dataSet;
        }
        
        // GET: api/FlightAPI/search/upcoming/{search}
        [HttpGet("search/upcoming/{search}")]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetUpcomingFlight(string search)
        {
            var flight = await _context.FlightDetails.Where(f => f.Origin.Contains(search) || f.Destination.Contains(search)).ToListAsync();

            if (flight == null)
            {
                return NotFound();
            }
            
            var dataSet = new List<FlightDetail>(); // old flights

            foreach (var item in flight)
            {
                if (item.FlightDate > DateTime.Now && item.FlightDate != DateTime.Now)
                {
                    dataSet.Add(item);
                }
            }
            
            return dataSet;
        }
        
        // GET: api/FlightAPI/search/today/{search}
        [HttpGet("search/today/{search}")]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetTodaysFlight(string search)
        {
            var flight = await _context.FlightDetails.Where(f => f.Origin.Contains(search) || f.Destination.Contains(search)).ToListAsync();

            if (flight == null)
            {
                return NotFound();
            }
            
            var dataSet = new List<FlightDetail>(); // old flights

            foreach (var item in flight)
            {
                if (item.FlightDate.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    dataSet.Add(item);
                }
            }
            
            return dataSet;
        }

        // GET: api/FlightAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetFlightDetails()
        {
            if (_context.FlightDetails == null)
            {
                return NotFound();
            }
            var flightData = await _context.FlightDetails.ToListAsync();
          
            var dataSetA = new List<FlightDetail>();
            var dataSetB = new List<FlightDetail>();

            foreach (var flight in flightData)
            {
                if (flight.FlightDate >= DateTime.Now)
                {
                    dataSetA.Add(flight);
                }
            }
          
            foreach (var flight in flightData)
            {
                if (flight.FlightDate.Date == DateTime.Now.Date)
                {
                    if (flight.DepartureTime.Add(new TimeSpan(0, 2, 0)) < DateTime.Now.TimeOfDay) 
                    { 
                        continue;
                    } 
                    dataSetB.Add(flight);
                }
            }
          
            dataSetB.AddRange(dataSetA);
            dataSetB = dataSetB.OrderBy(f => f.FlightDate).ToList();
          
            return dataSetB.Take(30).ToList();

        }
        
        // GET: api/FlightAPI/upcoming
        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetUpcomingFlightDetails()
        {
            if (_context.FlightDetails == null)
            {
                return NotFound();
            }
            var flight = await _context.FlightDetails.ToListAsync();
          
            if (flight == null)
            {
                return NotFound();
            }
            
            var dataSet = new List<FlightDetail>(); // old flights

            foreach (var item in flight)
            {
                if (item.FlightDate > DateTime.Now && item.FlightDate != DateTime.Now)
                {
                    dataSet.Add(item);
                }
            }
            
            return dataSet;

        }
        
        // GET: api/FlightAPI/past
        [HttpGet("past")]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetPastFlightDetails()
        {
            if (_context.FlightDetails == null)
            {
                return NotFound();
            }
            var flight = await _context.FlightDetails.ToListAsync();
          
            if (flight == null)
            {
                return NotFound();
            }
            
            var dataSet = new List<FlightDetail>(); // old flights

            foreach (var item in flight)
            {
                if (item.FlightDate < DateTime.Now && item.FlightDate.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    dataSet.Add(item);
                }
            }
            
            return dataSet;

        }
        
        // GET: api/FlightAPI/today
        [HttpGet("today")]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetTodaysFlightDetails()
        {
            if (_context.FlightDetails == null)
            {
                return NotFound();
            }
            var flight = await _context.FlightDetails.ToListAsync();
          
            if (flight == null)
            {
                return NotFound();
            }
            
            var dataSet = new List<FlightDetail>(); // old flights

            foreach (var item in flight)
            {
                if (item.FlightDate.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    dataSet.Add(item);
                }
            }
            
            return dataSet;

        }
        

        // GET: api/FlightAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDetail>> GetFlightDetail(int id)
        {
          if (_context.FlightDetails == null)
          {
              return NotFound();
          }
            var flightDetail = await _context.FlightDetails.FindAsync(id);

            if (flightDetail == null)
            {
                return NotFound();
            }

            return flightDetail;
        }

        // PUT: api/FlightAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightDetail(int id, FlightDetail flightDetail)
        {
            if (id != flightDetail.FlightId)
            {
                return BadRequest();
            }

            _context.Entry(flightDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FlightAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightDetail>> PostFlightDetail(FlightDetail flightDetail)
        {
          if (_context.FlightDetails == null)
          {
              return Problem("Entity set 'fidsContext.FlightDetails'  is null.");
          }
            _context.FlightDetails.Add(flightDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightDetail", new { id = flightDetail.FlightId }, flightDetail);
        }

        // DELETE: api/FlightAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightDetail(int id)
        {
            if (_context.FlightDetails == null)
            {
                return NotFound();
            }
            var flightDetail = await _context.FlightDetails.FindAsync(id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            _context.FlightDetails.Remove(flightDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightDetailExists(int id)
        {
            return (_context.FlightDetails?.Any(e => e.FlightId == id)).GetValueOrDefault();
        }
    }
}
