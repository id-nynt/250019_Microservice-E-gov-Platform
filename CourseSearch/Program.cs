using Microsoft.EntityFrameworkCore;
using CourseSearch.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Use SQLite DB

var dbPath = Environment.GetEnvironmentVariable("DB_PATH") ?? "data/courses.db";
var connectionString = $"Data Source={dbPath}";

builder.Services.AddDbContext<CourseDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CourseDbContext>();
    db.Database.Migrate();
}

// Enable Swagger always
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CourseSearch v1");
    c.RoutePrefix = "swagger";
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// Configure default files and static files
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

// Set URLs for Docker
var isRunningInContainer = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
if (isRunningInContainer)
{
    app.Urls.Clear();
    app.Urls.Add("http://*:80");
}

app.Run();