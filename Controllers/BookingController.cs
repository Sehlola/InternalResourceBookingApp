
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase {
    private readonly AppDbContext _db;
    public BookingController(AppDbContext db){ _db = db; }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _db.Bookings.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Booking b){
        _db.Bookings.Add(b);
        await _db.SaveChangesAsync();
        return Ok(b);
    }
}
