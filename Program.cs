
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=app.db")); // using sqlite for simplicity

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

public class Booking {
    public int Id {get;set;}
    public string ResourceName {get;set;} = "";
    public string BookedBy {get;set;} = "";
    public DateTime Date {get;set;}
}

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
    public DbSet<Booking> Bookings => Set<Booking>();
}
