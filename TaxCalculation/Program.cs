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

// Configure middleware pipeline in correct order
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaxCalculation v1"));
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

// app.MapFallbackToFile("index.html");

app.Run();