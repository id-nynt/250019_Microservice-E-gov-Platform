using Microsoft.EntityFrameworkCore;
using CourseSearch.Data;
using CourseSearch.Models;

var builder = WebApplication.CreateBuilder(args);

// Use SQLite DB stored in project folder (courses.db)
builder.Services.AddDbContext<CourseDbContext>(options =>
    options.UseSqlite("Data Source=courses.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serve static files from wwwroot
builder.Services.AddDirectoryBrowser();

var app = builder.Build();

// Ensure DB created and seed sample data (only if empty)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CourseDbContext>();
    db.Database.EnsureCreated();

    if (!db.Courses.Any())
    {
        db.Courses.AddRange(new List<Course>
        {
            // Information Technology
            new Course { CourseCode="IT101", CourseName="Intro to Programming", Level="Certificate IV", CourseArea="Information Technology", Location="Sydney", StudyOption="Full time", Duration="6 months", EstimatedFee=2500m },
            new Course { CourseCode="IT201", CourseName="Web Development Bootcamp", Level="Diploma", CourseArea="Information Technology", Location="Melbourne", StudyOption="Part time", Duration="9 months", EstimatedFee=6000m },
            new Course { CourseCode="IT301", CourseName="Cloud Computing Fundamentals", Level="Graduate Certificate", CourseArea="Information Technology", Location="Brisbane", StudyOption="Self-paced", Duration="6 months", EstimatedFee=4800m },
            new Course { CourseCode="IT401", CourseName="Data Science and Machine Learning", Level="Master", CourseArea="Information Technology", Location="Canberra", StudyOption="Full time", Duration="18 months", EstimatedFee=15000m },
            new Course { CourseCode="IT501", CourseName="Cyber Security Essentials", Level="Diploma", CourseArea="Information Technology", Location="Wollongong", StudyOption="Part time", Duration="12 months", EstimatedFee=7500m },

            // Health
            new Course { CourseCode="HLT100", CourseName="Certificate III in Individual Support", Level="Certificate III", CourseArea="Health", Location="Wollongong", StudyOption="Full time", Duration="12 months", EstimatedFee=4500m },
            new Course { CourseCode="HLT200", CourseName="Diploma of Nursing", Level="Diploma", CourseArea="Health", Location="Sydney", StudyOption="Full time", Duration="18 months", EstimatedFee=12000m },
            new Course { CourseCode="HLT300", CourseName="Community Health Worker Training", Level="Certificate IV", CourseArea="Health", Location="Melbourne", StudyOption="Part time", Duration="9 months", EstimatedFee=5200m },
            new Course { CourseCode="HLT400", CourseName="Mental Health Support", Level="Graduate Certificate", CourseArea="Health", Location="Adelaide", StudyOption="Self-paced", Duration="6 months", EstimatedFee=5000m },
            new Course { CourseCode="HLT500", CourseName="Public Health Policy", Level="Master", CourseArea="Health", Location="Canberra", StudyOption="Full time", Duration="24 months", EstimatedFee=16000m },

            // Trades
            new Course { CourseCode="TRD10", CourseName="Basic Carpentry Skills", Level="Certificate II", CourseArea="Trades", Location="Sydney", StudyOption="Full time", Duration="8 months", EstimatedFee=5000m },
            new Course { CourseCode="TRD20", CourseName="Electrical Apprenticeship", Level="Certificate III", CourseArea="Trades", Location="Melbourne", StudyOption="Full time", Duration="24 months", EstimatedFee=9000m },
            new Course { CourseCode="TRD30", CourseName="Plumbing Fundamentals", Level="Certificate II", CourseArea="Trades", Location="Adelaide", StudyOption="Part time", Duration="12 months", EstimatedFee=6000m },
            new Course { CourseCode="TRD40", CourseName="Welding and Fabrication", Level="Certificate IV", CourseArea="Trades", Location="Perth", StudyOption="Full time", Duration="18 months", EstimatedFee=11000m },
            new Course { CourseCode="TRD50", CourseName="Advanced Automotive Mechanics", Level="Diploma", CourseArea="Trades", Location="Brisbane", StudyOption="Full time", Duration="24 months", EstimatedFee=14000m },

            // Hospitality
            new Course { CourseCode="HOSP01", CourseName="Commercial Cookery", Level="Certificate IV", CourseArea="Hospitality", Location="Adelaide", StudyOption="Full time", Duration="12 months", EstimatedFee=7000m },
            new Course { CourseCode="HOSP02", CourseName="Diploma of Hotel Management", Level="Diploma", CourseArea="Hospitality", Location="Sydney", StudyOption="Part time", Duration="18 months", EstimatedFee=12000m },
            new Course { CourseCode="HOSP03", CourseName="Certificate III in Bakery", Level="Certificate III", CourseArea="Hospitality", Location="Melbourne", StudyOption="Full time", Duration="12 months", EstimatedFee=6500m },
            new Course { CourseCode="HOSP04", CourseName="Barista and Café Management", Level="Certificate II", CourseArea="Hospitality", Location="Wollongong", StudyOption="Self-paced", Duration="6 months", EstimatedFee=2800m },
            new Course { CourseCode="HOSP05", CourseName="Advanced Culinary Arts", Level="Graduate Certificate", CourseArea="Hospitality", Location="Brisbane", StudyOption="Full time", Duration="9 months", EstimatedFee=9500m },

            // Creative Arts
            new Course { CourseCode="CREA1", CourseName="Introduction to Fashion Design", Level="Certificate II", CourseArea="Creative Arts", Location="Melbourne", StudyOption="Part time", Duration="6 months", EstimatedFee=3000m },
            new Course { CourseCode="CREA2", CourseName="Diploma of Interior Design", Level="Diploma", CourseArea="Creative Arts", Location="Sydney", StudyOption="Full time", Duration="18 months", EstimatedFee=11000m },
            new Course { CourseCode="CREA3", CourseName="Certificate IV in Photography", Level="Certificate IV", CourseArea="Creative Arts", Location="Adelaide", StudyOption="Full time", Duration="12 months", EstimatedFee=6500m },
            new Course { CourseCode="CREA4", CourseName="Bachelor of Fine Arts", Level="Bachelor", CourseArea="Creative Arts", Location="Brisbane", StudyOption="Full time", Duration="36 months", EstimatedFee=28000m },
            new Course { CourseCode="CREA5", CourseName="Certificate III in Graphic Design", Level="Certificate III", CourseArea="Creative Arts", Location="Canberra", StudyOption="Self-paced", Duration="9 months", EstimatedFee=4000m },

            // Business and Administration
            new Course { CourseCode="BUS101", CourseName="Business Administration Basics", Level="Diploma", CourseArea="Business and Administration", Location="Sydney", StudyOption="Self-paced", Duration="6 months", EstimatedFee=2000m },
            new Course { CourseCode="BUS201", CourseName="Certificate IV in Leadership", Level="Certificate IV", CourseArea="Business and Administration", Location="Melbourne", StudyOption="Part time", Duration="12 months", EstimatedFee=4500m },
            new Course { CourseCode="BUS301", CourseName="Bachelor of Commerce", Level="Bachelor", CourseArea="Business and Administration", Location="Adelaide", StudyOption="Full time", Duration="36 months", EstimatedFee=30000m },
            new Course { CourseCode="BUS401", CourseName="Graduate Diploma in Project Management", Level="Graduate Diploma", CourseArea="Business and Administration", Location="Brisbane", StudyOption="Full time", Duration="12 months", EstimatedFee=12000m },
            new Course { CourseCode="BUS501", CourseName="Master of Business Administration", Level="Master", CourseArea="Business and Administration", Location="Canberra", StudyOption="Full time", Duration="24 months", EstimatedFee=35000m },

            // Agriculture
            new Course { CourseCode="AG01", CourseName="Agricultural Practices", Level="Certificate III", CourseArea="Agriculture", Location="Regional NSW", StudyOption="Full time", Duration="9 months", EstimatedFee=4200m },
            new Course { CourseCode="AG02", CourseName="Certificate IV in Horticulture", Level="Certificate IV", CourseArea="Agriculture", Location="Melbourne", StudyOption="Part time", Duration="12 months", EstimatedFee=5500m },
            new Course { CourseCode="AG03", CourseName="Diploma of Agribusiness", Level="Diploma", CourseArea="Agriculture", Location="Brisbane", StudyOption="Full time", Duration="18 months", EstimatedFee=9000m },
            new Course { CourseCode="AG04", CourseName="Bachelor of Agricultural Science", Level="Bachelor", CourseArea="Agriculture", Location="Adelaide", StudyOption="Full time", Duration="36 months", EstimatedFee=28000m },
            new Course { CourseCode="AG05", CourseName="Sustainable Farming Practices", Level="Graduate Certificate", CourseArea="Agriculture", Location="Sydney", StudyOption="Self-paced", Duration="6 months", EstimatedFee=7000m }
        });
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseDirectoryBrowser();

app.UseAuthorization();
app.MapControllers();

// Serve index.html at root
app.MapFallbackToFile("index.html");

// Run on fixed port 6003
app.Urls.Clear();
app.Urls.Add("http://localhost:6003");

app.Run();