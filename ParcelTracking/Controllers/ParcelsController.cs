using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcelTracking.Data;

namespace ParcelTracking.Controllers
{
    [ApiController]
    [Route("api/parcels")]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelDbContext _db;

        public ParcelController(ParcelDbContext db)
        {
            _db = db;
        }

        // GET /api/parcels/{trackingNumber}
        [HttpGet("{trackingNumber}")]
        public async Task<IActionResult> GetByTracking(string trackingNumber)
        {
            if (string.IsNullOrWhiteSpace(trackingNumber))
                return BadRequest(new { message = "Tracking number is required." });

            var parcel = await _db.Parcels
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.TrackingNumber == trackingNumber);

            if (parcel == null)
                return NotFound(new { message = "No such parcel found." });

            return Ok(parcel);
        }
    }
}