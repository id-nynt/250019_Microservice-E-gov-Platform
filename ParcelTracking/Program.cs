using Microsoft.EntityFrameworkCore;
using ParcelTracking.Data;

var builder = WebApplication.CreateBuilder(args);

// SQLite connection
var conn = builder.Configuration.GetConnectionString("ParcelDb") ?? "Data Source=parcel.db";
builder.Services.AddDbContext<ParcelDbContext>(opt => opt.UseSqlite(conn));

// MVC + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Static files (wwwroot) for your search page
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

// Ensure database & migrations applied
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ParcelDbContext>();
    db.Database.Migrate();
}

app.Run();