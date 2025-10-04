using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseSearch.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { "AG02", "Agriculture", "Horticulture", "12 months", 5500m, "Certificate IV", "Melbourne", "Part time" },
                    { "AG03", "Agriculture", "Agribusiness", "18 months", 9000m, "Diploma", "Brisbane", "Full time" },
                    { "AG04", "Agriculture", "Agricultural Science", "36 months", 28000m, "Diploma", "Adelaide", "Full time" },
                    { "AG05", "Agriculture", "Sustainable Farming Practices", "6 months", 7000m, "Graduate Certificate", "Sydney", "Self-paced" },
                    { "AG06", "Agriculture", "Rural Operations", "9 months", 3000m, "Certificate II", "Regional NSW", "Full time" },
                    { "AG07", "Agriculture", "Viticulture", "18 months", 8500m, "Diploma", "Adelaide", "Part time" },
                    { "AG08", "Agriculture", "Agricultural Economics", "12 months", 9000m, "Graduate Certificate", "Canberra", "Full time" },
                    { "AG09", "Agriculture", "Wool Classing", "12 months", 5500m, "Certificate IV", "Melbourne", "Full time" },
                    { "AG10", "Agriculture", "Animal Science", "36 months", 28000m, "Diploma", "Sydney", "Full time" },
                    { "AG11", "Agriculture", "Organic Farming", "18 months", 9000m, "Diploma", "Regional QLD", "Full time" },
                    { "AG12", "Agriculture", "Crop Science", "18 months", 11000m, "Graduate Diploma", "Brisbane", "Part time" },
                    { "AG13", "Agriculture", "Agricultural Machinery", "12 months", 6000m, "Certificate III", "Adelaide", "Full time" },
                    { "AG14", "Agriculture", "Aquaculture", "12 months", 6500m, "Certificate IV", "Perth", "Full time" },
                    { "AG15", "Agriculture", "Sustainable Agriculture", "24 months", 20000m, "Diploma", "Canberra", "Full time" },
                    { "BUS101", "Business and Administration", "Business Administration Basics", "6 months", 2000m, "Diploma", "Sydney", "Self-paced" },
                    { "BUS201", "Business and Administration", "Leadership", "12 months", 4500m, "Certificate IV", "Melbourne", "Part time" },
                    { "BUS301", "Business and Administration", "Commerce", "36 months", 30000m, "Diploma", "Adelaide", "Full time" },
                    { "BUS401", "Business and Administration", "Project Management", "12 months", 12000m, "Graduate Diploma", "Brisbane", "Full time" },
                    { "BUS501", "Business and Administration", "Business Administration", "24 months", 35000m, "Diploma", "Canberra", "Full time" },
                    { "BUS601", "Business and Administration", "Advanced Human Resource Management", "12 months", 12500m, "Graduate Diploma", "Sydney", "Full time" },
                    { "BUS602", "Business and Administration", "Small Business Management", "12 months", 4800m, "Certificate IV", "Melbourne", "Part time" },
                    { "BUS603", "Business and Administration", "International Business", "24 months", 33000m, "Master", "Canberra", "Full time" },
                    { "BUS604", "Business and Administration", "Logistics and Supply Chain", "12 months", 9500m, "Graduate Certificate", "Brisbane", "Part time" },
                    { "BUS605", "Business and Administration", "Marketing and Communications", "12 months", 5200m, "Certificate IV", "Adelaide", "Full time" },
                    { "BUS606", "Business and Administration", "Accounting", "36 months", 30000m, "Diploma", "Sydney", "Full time" },
                    { "BUS607", "Business and Administration", "E-Commerce", "18 months", 10000m, "Diploma", "Melbourne", "Full time" },
                    { "BUS608", "Business and Administration", "Business Operations", "9 months", 3500m, "Certificate III", "Brisbane", "Part time" },
                    { "BUS609", "Business and Administration", "Finance", "18 months", 12000m, "Graduate Diploma", "Sydney", "Part time" },
                    { "BUS610", "Business and Administration", "Master of Entrepreneurship", "24 months", 34000m, "Master", "Canberra", "Full time" },
                    { "BUS611", "Business and Administration", "Project Coordination", "12 months", 4700m, "Certificate IV", "Perth", "Part time" },
                    { "BUS612", "Business and Administration", "Advanced Diploma in Strategic Leadership", "18 months", 11500m, "Diploma", "Sydney", "Full time" },
                    { "CREA1", "Creative Arts", "Introduction to Fashion Design", "6 months", 3000m, "Certificate II", "Melbourne", "Part time" },
                    { "CREA10", "Creative Arts", "Film and Television Studies", "18 months", 11000m, "Diploma", "Adelaide", "Full time" },
                    { "CREA11", "Creative Arts", "Fine Arts", "24 months", 24000m, "Diploma", "Sydney", "Full time" },
                    { "CREA12", "Creative Arts", "Game Art", "12 months", 6500m, "Certificate IV", "Brisbane", "Part time" },
                    { "CREA13", "Creative Arts", "Advanced Photography Techniques", "12 months", 7800m, "Diploma", "Melbourne", "Full time" },
                    { "CREA14", "Creative Arts", "Theatre Production and Stage Design", "18 months", 10000m, "Diploma", "Sydney", "Part time" },
                    { "CREA15", "Creative Arts", "Creative Writing", "9 months", 4000m, "Certificate III", "Wollongong", "Self-paced" },
                    { "CREA2", "Creative Arts", "Interior Design", "18 months", 11000m, "Diploma", "Sydney", "Full time" },
                    { "CREA3", "Creative Arts", "Photography", "12 months", 6500m, "Certificate IV", "Adelaide", "Full time" },
                    { "CREA4", "Creative Arts", "Fine Arts", "36 months", 28000m, "Diploma", "Brisbane", "Full time" },
                    { "CREA5", "Creative Arts", "Graphic Design", "9 months", 4000m, "Certificate III", "Canberra", "Self-paced" },
                    { "CREA6", "Creative Arts", "Digital Animation and 3D Modelling", "18 months", 12000m, "Diploma", "Brisbane", "Full time" },
                    { "CREA7", "Creative Arts", "Acting and Performance", "12 months", 6500m, "Certificate IV", "Sydney", "Part time" },
                    { "CREA8", "Creative Arts", "Music Production", "36 months", 28000m, "Diploma", "Melbourne", "Full time" },
                    { "CREA9", "Creative Arts", "Digital Illustration", "9 months", 5000m, "Certificate III", "Canberra", "Full time" },
                    { "HLT100", "Health", "Individual Support", "12 months", 4500m, "Certificate III", "Wollongong", "Full time" },
                    { "HLT200", "Health", "Nursing", "18 months", 12000m, "Diploma", "Sydney", "Full time" },
                    { "HLT300", "Health", "Community Health Worker Training", "9 months", 5200m, "Certificate IV", "Melbourne", "Part time" },
                    { "HLT400", "Health", "Mental Health Support", "6 months", 5000m, "Graduate Certificate", "Adelaide", "Self-paced" },
                    { "HLT500", "Health", "Public Health Policy", "24 months", 16000m, "Master", "Canberra", "Full time" },
                    { "HLT600", "Health", "Audiometry", "6 months", 6000m, "Diploma", "Perth", "Full time" },
                    { "HLT700", "Health", "Dental Assisting", "12 months", 12000m, "Certificate III", "Canberra", "Part time" },
                    { "HLT701", "Health", "Dental Radiography", "12 months", 12000m, "Certificate IV", "Canberra", "Part time" },
                    { "HLT800", "Health", "Allied Health Assistance", "12 months", 5200m, "Certificate IV", "Sydney", "Full time" },
                    { "HLT801", "Health", "Paramedical Science", "18 months", 10500m, "Diploma", "Brisbane", "Part time" },
                    { "HLT802", "Health", "Mental Health Nursing", "12 months", 8000m, "Graduate Certificate", "Melbourne", "Part time" },
                    { "HLT803", "Health", "Advanced Pathology Collection", "9 months", 6200m, "Diploma", "Adelaide", "Full time" },
                    { "HLT804", "Health", "Midwifery Practice", "24 months", 20000m, "Master", "Canberra", "Full time" },
                    { "HLT805", "Health", "Physiotherapy Rehabilitation Techniques", "18 months", 11000m, "Graduate Diploma", "Wollongong", "Part time" },
                    { "HLT806", "Health", "Nutrition and Dietetics", "12 months", 7500m, "Diploma", "Sydney", "Full time" },
                    { "HLT807", "Health", "Public Health Epidemiology", "24 months", 17000m, "Master", "Brisbane", "Part time" },
                    { "HLT808", "Health", "Occupational Therapy", "12 months", 9500m, "Graduate Certificate", "Perth", "Part time" },
                    { "HLT809", "Health", "Community Aged Care Support", "9 months", 4800m, "Certificate IV", "Melbourne", "Full time" },
                    { "HLT810", "Health", "Speech Pathology Fundamentals", "12 months", 7800m, "Diploma", "Canberra", "Full time" },
                    { "HLT811", "Health", "Healthcare Management", "18 months", 12000m, "Graduate Diploma", "Sydney", "Full time" },
                    { "HOSP01", "Hospitality", "Commercial Cookery", "12 months", 7000m, "Certificate IV", "Adelaide", "Full time" },
                    { "HOSP02", "Hospitality", "Hotel Management", "18 months", 12000m, "Diploma", "Sydney", "Part time" },
                    { "HOSP03", "Hospitality", "Bakery", "12 months", 6500m, "Certificate III", "Melbourne", "Full time" },
                    { "HOSP04", "Hospitality", "Barista and Café Management", "6 months", 2800m, "Certificate II", "Wollongong", "Self-paced" },
                    { "HOSP05", "Hospitality", "Advanced Culinary Arts", "9 months", 9500m, "Graduate Certificate", "Brisbane", "Full time" },
                    { "HOSP06", "Hospitality", "Event Management Essentials", "12 months", 8500m, "Diploma", "Sydney", "Full time" },
                    { "HOSP07", "Hospitality", "Patisserie", "12 months", 6500m, "Certificate III", "Melbourne", "Full time" },
                    { "HOSP08", "Hospitality", "Advanced Wine and Beverage Studies", "12 months", 7200m, "Graduate Certificate", "Adelaide", "Part time" },
                    { "HOSP09", "Hospitality", "Hospitality Management", "18 months", 9800m, "Certificate IV", "Brisbane", "Full time" },
                    { "HOSP10", "Hospitality", "Hotel Operations and Guest Services", "18 months", 11000m, "Diploma", "Sydney", "Part time" },
                    { "HOSP11", "Hospitality", "Bar Management", "12 months", 6200m, "Certificate IV", "Perth", "Full time" },
                    { "HOSP12", "Hospitality", "Restaurant Entrepreneurship", "18 months", 12500m, "Graduate Diploma", "Canberra", "Part time" },
                    { "HOSP13", "Hospitality", "Food and Beverage", "6 months", 3000m, "Certificate II", "Sydney", "Full time" },
                    { "HOSP14", "Hospitality", "Travel and Tourism Management", "12 months", 9000m, "Diploma", "Melbourne", "Full time" },
                    { "HOSP15", "Hospitality", "Advanced Catering Services", "12 months", 7000m, "Certificate IV", "Wollongong", "Part time" },
                    { "IT101", "Information Technology", "Intro to Programming", "6 months", 2500m, "Certificate IV", "Sydney", "Full time" },
                    { "IT102", "Information Technology", "Hardware Technician Skill Set", "3 months", 1500m, "Statement of Attainment", "Sydney", "Full time" },
                    { "IT103", "Information Technology", "Applied Digital Technologies", "12 months", 4000m, "Master", "Wollongong", "Part time" },
                    { "IT104", "Information Technology", "Systems Administration Support", "12 months", 6500m, "Certificate IV", "Melbourne", "Full time" },
                    { "IT105", "Information Technology", "Advanced Networking, Cloud Architecture", "6 months", 4000m, "Diploma", "Sydney", "Full time" },
                    { "IT106", "Information Technology", "Database and Data Management", "6 months", 4000m, "Diploma", "Perth", "Full time" },
                    { "IT107", "Information Technology", "Business Analysis", "12 months", 7500m, "Graduate Certificate", "Sydney", "Full time" },
                    { "IT201", "Information Technology", "Web Development Bootcamp", "9 months", 6000m, "Diploma", "Melbourne", "Part time" },
                    { "IT202", "Information Technology", "Web Development for Introductory Roles Skill Set", "3 months", 2000m, "Statement of Attainment", "Melbourne", "Full time" },
                    { "IT203", "Information Technology", "Back End Web Development", "12 months", 4000m, "Diploma", "Sydney", "Part time" },
                    { "IT204", "Information Technology", "Front End Web Development", "12 months", 4000m, "Diploma", "Sydney", "Part time" },
                    { "IT301", "Information Technology", "Cloud Computing Fundamentals", "6 months", 4800m, "Graduate Certificate", "Brisbane", "Self-paced" },
                    { "IT401", "Information Technology", "Data Science and Machine Learning", "18 months", 15000m, "Master", "Canberra", "Full time" },
                    { "IT402", "Information Technology", "Computer Vision Algorithms", "6 months", 6000m, "Diploma", "Melbourne", "Full time" },
                    { "IT403", "Information Technology", "Big Data Management", "12 months", 12000m, "Master", "Canberra", "Full time" },
                    { "IT404", "Information Technology", "Natural Language Processing Systems", "6 months", 6500m, "Certificate IV", "Wollongong", "Full time" },
                    { "IT405", "Information Technology", "Applied Data Science in Security", "36 months", 40000m, "Master", "Canberra", "Full time" },
                    { "IT501", "Information Technology", "Cyber Security Essentials", "12 months", 7500m, "Diploma", "Wollongong", "Part time" },
                    { "IT502", "Information Technology", "Digital Security and Privacy", "18 months", 16000m, "Graduate Certificate", "Sydney", "Full time" },
                    { "IT503", "Information Technology", "Cyber Security and Advanced Networking", "12 months", 9500m, "Certificate IV", "Wollongong", "Full time" },
                    { "IT504", "Information Technology", "Cryptography Fundamentals", "12 months", 7500m, "Diploma", "Wollongong", "Part time" },
                    { "IT505", "Information Technology", "Modern Cryptography", "24 months", 20000m, "Master", "Sydney", "Part time" },
                    { "TRD10", "Trades", "Basic Carpentry Skills", "8 months", 5000m, "Certificate II", "Sydney", "Full time" },
                    { "TRD20", "Trades", "Electrical Apprenticeship", "24 months", 9000m, "Certificate III", "Melbourne", "Full time" },
                    { "TRD30", "Trades", "Plumbing Fundamentals", "12 months", 6000m, "Certificate II", "Adelaide", "Part time" },
                    { "TRD40", "Trades", "Welding and Fabrication", "18 months", 11000m, "Certificate IV", "Perth", "Full time" },
                    { "TRD50", "Trades", "Advanced Automotive Mechanics", "24 months", 14000m, "Diploma", "Brisbane", "Full time" },
                    { "TRD60", "Trades", "Advanced Bricklaying", "12 months", 7000m, "Certificate III", "Canberra", "Full time" },
                    { "TRD61", "Trades", "Building and Construction", "18 months", 9500m, "Certificate IV", "Brisbane", "Part time" },
                    { "TRD62", "Trades", "Automotive Electrical Technology", "24 months", 12000m, "Certificate III", "Melbourne", "Full time" },
                    { "TRD63", "Trades", "Painting and Decorating", "12 months", 6000m, "Certificate III", "Adelaide", "Part time" },
                    { "TRD64", "Trades", "Advanced Metal Fabrication", "18 months", 13500m, "Diploma", "Sydney", "Full time" },
                    { "TRD65", "Trades", "Refrigeration and Air Conditioning", "24 months", 14000m, "Certificate IV", "Perth", "Full time" },
                    { "TRD66", "Trades", "Joinery", "12 months", 6500m, "Certificate III", "Wollongong", "Full time" },
                    { "TRD67", "Trades", "Engineering Trades", "24 months", 14500m, "Diploma", "Melbourne", "Part time" },
                    { "TRD68", "Trades", "Advanced Electrical Control Systems", "12 months", 8000m, "Graduate Certificate", "Canberra", "Part time" },
                    { "TRD69", "Trades", "Automotive Air Conditioning", "6 months", 4000m, "Certificate II", "Sydney", "Full time" }
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
