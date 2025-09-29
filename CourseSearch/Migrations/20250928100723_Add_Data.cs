using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseSearch.Migrations
{
    /// <inheritdoc />
    public partial class Add_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "TEXT", nullable: false),
                    CourseName = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<string>(type: "TEXT", nullable: false),
                    CourseArea = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    StudyOption = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: false),
                    EstimatedFee = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseCode);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseCode", "CourseArea", "CourseName", "Duration", "EstimatedFee", "Level", "Location", "StudyOption" },
                values: new object[,]
                {
                    { "AG01", "Agriculture", "Agricultural Practices", "9 months", 4200m, "Certificate III", "Regional NSW", "Full time" },
                    { "AG02", "Agriculture", "Certificate IV in Horticulture", "12 months", 5500m, "Certificate IV", "Melbourne", "Part time" },
                    { "AG03", "Agriculture", "Diploma of Agribusiness", "18 months", 9000m, "Diploma", "Brisbane", "Full time" },
                    { "AG04", "Agriculture", "Bachelor of Agricultural Science", "36 months", 28000m, "Bachelor", "Adelaide", "Full time" },
                    { "AG05", "Agriculture", "Sustainable Farming Practices", "6 months", 7000m, "Graduate Certificate", "Sydney", "Self-paced" },
                    { "BUS101", "Business and Administration", "Business Administration Basics", "6 months", 2000m, "Diploma", "Sydney", "Self-paced" },
                    { "BUS201", "Business and Administration", "Certificate IV in Leadership", "12 months", 4500m, "Certificate IV", "Melbourne", "Part time" },
                    { "BUS301", "Business and Administration", "Bachelor of Commerce", "36 months", 30000m, "Bachelor", "Adelaide", "Full time" },
                    { "BUS401", "Business and Administration", "Graduate Diploma in Project Management", "12 months", 12000m, "Graduate Diploma", "Brisbane", "Full time" },
                    { "BUS501", "Business and Administration", "Master of Business Administration", "24 months", 35000m, "Master", "Canberra", "Full time" },
                    { "CREA1", "Creative Arts", "Introduction to Fashion Design", "6 months", 3000m, "Certificate II", "Melbourne", "Part time" },
                    { "CREA2", "Creative Arts", "Diploma of Interior Design", "18 months", 11000m, "Diploma", "Sydney", "Full time" },
                    { "CREA3", "Creative Arts", "Certificate IV in Photography", "12 months", 6500m, "Certificate IV", "Adelaide", "Full time" },
                    { "CREA4", "Creative Arts", "Bachelor of Fine Arts", "36 months", 28000m, "Bachelor", "Brisbane", "Full time" },
                    { "CREA5", "Creative Arts", "Certificate III in Graphic Design", "9 months", 4000m, "Certificate III", "Canberra", "Self-paced" },
                    { "HLT100", "Health", "Certificate III in Individual Support", "12 months", 4500m, "Certificate III", "Wollongong", "Full time" },
                    { "HLT200", "Health", "Diploma of Nursing", "18 months", 12000m, "Diploma", "Sydney", "Full time" },
                    { "HLT300", "Health", "Community Health Worker Training", "9 months", 5200m, "Certificate IV", "Melbourne", "Part time" },
                    { "HLT400", "Health", "Mental Health Support", "6 months", 5000m, "Graduate Certificate", "Adelaide", "Self-paced" },
                    { "HLT500", "Health", "Public Health Policy", "24 months", 16000m, "Master", "Canberra", "Full time" },
                    { "HOSP01", "Hospitality", "Commercial Cookery", "12 months", 7000m, "Certificate IV", "Adelaide", "Full time" },
                    { "HOSP02", "Hospitality", "Diploma of Hotel Management", "18 months", 12000m, "Diploma", "Sydney", "Part time" },
                    { "HOSP03", "Hospitality", "Certificate III in Bakery", "12 months", 6500m, "Certificate III", "Melbourne", "Full time" },
                    { "HOSP04", "Hospitality", "Barista and Café Management", "6 months", 2800m, "Certificate II", "Wollongong", "Self-paced" },
                    { "HOSP05", "Hospitality", "Advanced Culinary Arts", "9 months", 9500m, "Graduate Certificate", "Brisbane", "Full time" },
                    { "IT101", "Information Technology", "Intro to Programming", "6 months", 2500m, "Certificate IV", "Sydney", "Full time" },
                    { "IT201", "Information Technology", "Web Development Bootcamp", "9 months", 6000m, "Diploma", "Melbourne", "Part time" },
                    { "IT301", "Information Technology", "Cloud Computing Fundamentals", "6 months", 4800m, "Graduate Certificate", "Brisbane", "Self-paced" },
                    { "IT401", "Information Technology", "Data Science and Machine Learning", "18 months", 15000m, "Master", "Canberra", "Full time" },
                    { "IT501", "Information Technology", "Cyber Security Essentials", "12 months", 7500m, "Diploma", "Wollongong", "Part time" },
                    { "TRD10", "Trades", "Basic Carpentry Skills", "8 months", 5000m, "Certificate II", "Sydney", "Full time" },
                    { "TRD20", "Trades", "Electrical Apprenticeship", "24 months", 9000m, "Certificate III", "Melbourne", "Full time" },
                    { "TRD30", "Trades", "Plumbing Fundamentals", "12 months", 6000m, "Certificate II", "Adelaide", "Part time" },
                    { "TRD40", "Trades", "Welding and Fabrication", "18 months", 11000m, "Certificate IV", "Perth", "Full time" },
                    { "TRD50", "Trades", "Advanced Automotive Mechanics", "24 months", 14000m, "Diploma", "Brisbane", "Full time" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
