using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serve static files from wwwroot
builder.Services.AddDirectoryBrowser();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS redirection only in production
if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// enable static files (wwwroot)
app.UseStaticFiles();
app.UseDirectoryBrowser();

app.UseAuthorization();
app.MapControllers();

// fallback so visiting http://localhost:6002/ serves wwwroot/index.html
app.MapFallbackToFile("index.html");

// Force the app to listen on port 6002 (HTTP)
app.Urls.Clear();
app.Urls.Add("http://localhost:6002");

app.Run();
