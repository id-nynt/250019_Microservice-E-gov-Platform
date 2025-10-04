using CourseSearch.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseSearch.Data
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>

    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
            // Information Technology
            new Course { CourseCode = "IT101", CourseName = "Intro to Programming", Level = "Certificate IV", CourseArea = "Information Technology", Location = "Sydney", StudyOption = "Full time", Duration = "6 months", EstimatedFee = 2500m },
            new Course { CourseCode = "IT102", CourseName = "Hardware Technician Skill Set", Level = "Statement of Attainment", CourseArea = "Information Technology", Location = "Sydney", StudyOption = "Full time", Duration = "3 months", EstimatedFee = 1500m },
            new Course { CourseCode = "IT103", CourseName = "Applied Digital Technologies", Level = "Master", CourseArea = "Information Technology", Location = "Wollongong", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 4000m },
            new Course { CourseCode = "IT104", CourseName = "Systems Administration Support", Level = "Certificate IV", CourseArea = "Information Technology", Location = "Melbourne", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 6500m },
            new Course { CourseCode = "IT105", CourseName = "Advanced Networking, Cloud Architecture", Level = "Diploma", CourseArea = "Information Technology", Location = "Sydney", StudyOption = "Full time", Duration = "6 months", EstimatedFee = 4000m },
            new Course { CourseCode = "IT106", CourseName = "Database and Data Management", Level = "Diploma", CourseArea = "Information Technology", Location = "Perth", StudyOption = "Full time", Duration = "6 months", EstimatedFee = 4000m },
            new Course { CourseCode = "IT107", CourseName = "Business Analysis", Level = "Graduate Certificate", CourseArea = "Information Technology", Location = "Sydney", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 7500m },
            new Course { CourseCode = "IT201", CourseName = "Web Development Bootcamp", Level = "Diploma", CourseArea = "Information Technology", Location = "Melbourne", StudyOption = "Part time", Duration = "9 months", EstimatedFee = 6000m },
            new Course { CourseCode = "IT202", CourseName = "Web Development for Introductory Roles Skill Set", Level = "Statement of Attainment", CourseArea = "Information Technology", Location = "Melbourne", StudyOption = "Full time", Duration = "3 months", EstimatedFee = 2000m },
            new Course { CourseCode = "IT203", CourseName = "Back End Web Development", Level = "Diploma", CourseArea = "Information Technology", Location = "Sydney", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 4000m },
            new Course { CourseCode = "IT204", CourseName = "Front End Web Development", Level = "Diploma", CourseArea = "Information Technology", Location = "Sydney", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 4000m },
            new Course { CourseCode = "IT301", CourseName = "Cloud Computing Fundamentals", Level = "Graduate Certificate", CourseArea = "Information Technology", Location = "Brisbane", StudyOption = "Self-paced", Duration = "6 months", EstimatedFee = 4800m },
            new Course { CourseCode = "IT401", CourseName = "Data Science and Machine Learning", Level = "Master", CourseArea = "Information Technology", Location = "Canberra", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 15000m },
            new Course { CourseCode = "IT402", CourseName = "Computer Vision Algorithms", Level = "Diploma", CourseArea = "Information Technology", Location = "Melbourne", StudyOption = "Full time", Duration = "6 months", EstimatedFee = 6000m },
            new Course { CourseCode = "IT403", CourseName = "Big Data Management", Level = "Master", CourseArea = "Information Technology", Location = "Canberra", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 12000m },
            new Course { CourseCode = "IT404", CourseName = "Natural Language Processing Systems", Level = "Certificate IV", CourseArea = "Information Technology", Location = "Wollongong", StudyOption = "Full time", Duration = "6 months", EstimatedFee = 6500m },
            new Course { CourseCode = "IT405", CourseName = "Applied Data Science in Security", Level = "Master", CourseArea = "Information Technology", Location = "Canberra", StudyOption = "Full time", Duration = "36 months", EstimatedFee = 40000m },
            new Course { CourseCode = "IT501", CourseName = "Cyber Security Essentials", Level = "Diploma", CourseArea = "Information Technology", Location = "Wollongong", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 7500m },
            new Course { CourseCode = "IT502", CourseName = "Digital Security and Privacy", Level = "Graduate Certificate", CourseArea = "Information Technology", Location = "Sydney", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 16000m },
            new Course { CourseCode = "IT503", CourseName = "Cyber Security and Advanced Networking", Level = "Certificate IV", CourseArea = "Information Technology", Location = "Wollongong", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 9500m },
            new Course { CourseCode = "IT504", CourseName = "Cryptography Fundamentals", Level = "Diploma", CourseArea = "Information Technology", Location = "Wollongong", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 7500m },
            new Course { CourseCode = "IT505", CourseName = "Modern Cryptography", Level = "Master", CourseArea = "Information Technology", Location = "Sydney", StudyOption = "Part time", Duration = "24 months", EstimatedFee = 20000m },


            // Health
            new Course { CourseCode = "HLT100", CourseName = "Individual Support", Level = "Certificate III", CourseArea = "Health", Location = "Wollongong", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 4500m },
            new Course { CourseCode = "HLT200", CourseName = "Nursing", Level = "Diploma", CourseArea = "Health", Location = "Sydney", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 12000m },
            new Course { CourseCode = "HLT300", CourseName = "Community Health Worker Training", Level = "Certificate IV", CourseArea = "Health", Location = "Melbourne", StudyOption = "Part time", Duration = "9 months", EstimatedFee = 5200m },
            new Course { CourseCode = "HLT400", CourseName = "Mental Health Support", Level = "Graduate Certificate", CourseArea = "Health", Location = "Adelaide", StudyOption = "Self-paced", Duration = "6 months", EstimatedFee = 5000m },
            new Course { CourseCode = "HLT500", CourseName = "Public Health Policy", Level = "Master", CourseArea = "Health", Location = "Canberra", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 16000m },
            new Course { CourseCode = "HLT600", CourseName = "Audiometry", Level = "Diploma", CourseArea = "Health", Location = "Perth", StudyOption = "Full time", Duration = "6 months", EstimatedFee = 6000m },
            new Course { CourseCode = "HLT700", CourseName = "Dental Assisting", Level = "Certificate III", CourseArea = "Health", Location = "Canberra", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 12000m },
            new Course { CourseCode = "HLT701", CourseName = "Dental Radiography", Level = "Certificate IV", CourseArea = "Health", Location = "Canberra", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 12000m },
            new Course { CourseCode = "HLT800", CourseName = "Allied Health Assistance", Level = "Certificate IV", CourseArea = "Health", Location = "Sydney", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 5200m },
            new Course { CourseCode = "HLT801", CourseName = "Paramedical Science", Level = "Diploma", CourseArea = "Health", Location = "Brisbane", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 10500m },
            new Course { CourseCode = "HLT802", CourseName = "Graduate Certificate in Mental Health Nursing", Level = "Graduate Certificate", CourseArea = "Health", Location = "Melbourne", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 8000m },
            new Course { CourseCode = "HLT803", CourseName = "Advanced Pathology Collection", Level = "Diploma", CourseArea = "Health", Location = "Adelaide", StudyOption = "Full time", Duration = "9 months", EstimatedFee = 6200m },
            new Course { CourseCode = "HLT804", CourseName = "Midwifery Practice", Level = "Master", CourseArea = "Health", Location = "Canberra", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 20000m },
            new Course { CourseCode = "HLT805", CourseName = "Physiotherapy Rehabilitation Techniques", Level = "Graduate Diploma", CourseArea = "Health", Location = "Wollongong", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 11000m },
            new Course { CourseCode = "HLT806", CourseName = "Nutrition and Dietetics", Level = "Diploma", CourseArea = "Health", Location = "Sydney", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 7500m },
            new Course { CourseCode = "HLT807", CourseName = "Public Health Epidemiology", Level = "Master", CourseArea = "Health", Location = "Brisbane", StudyOption = "Part time", Duration = "24 months", EstimatedFee = 17000m },
            new Course { CourseCode = "HLT808", CourseName = "Graduate Certificate in Occupational Therapy", Level = "Graduate Certificate", CourseArea = "Health", Location = "Perth", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 9500m },
            new Course { CourseCode = "HLT809", CourseName = "Community Aged Care Support", Level = "Certificate IV", CourseArea = "Health", Location = "Melbourne", StudyOption = "Full time", Duration = "9 months", EstimatedFee = 4800m },
            new Course { CourseCode = "HLT810", CourseName = "Speech Pathology Fundamentals", Level = "Diploma", CourseArea = "Health", Location = "Canberra", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 7800m },
            new Course { CourseCode = "HLT811", CourseName = "Healthcare Management", Level = "Graduate Diploma", CourseArea = "Health", Location = "Sydney", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 12000m },


            // Trades
            new Course { CourseCode = "TRD10", CourseName = "Basic Carpentry Skills", Level = "Certificate II", CourseArea = "Trades", Location = "Sydney", StudyOption = "Full time", Duration = "8 months", EstimatedFee = 5000m },
            new Course { CourseCode = "TRD20", CourseName = "Electrical Apprenticeship", Level = "Certificate III", CourseArea = "Trades", Location = "Melbourne", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 9000m },
            new Course { CourseCode = "TRD30", CourseName = "Plumbing Fundamentals", Level = "Certificate II", CourseArea = "Trades", Location = "Adelaide", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 6000m },
            new Course { CourseCode = "TRD40", CourseName = "Welding and Fabrication", Level = "Certificate IV", CourseArea = "Trades", Location = "Perth", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 11000m },
            new Course { CourseCode = "TRD50", CourseName = "Advanced Automotive Mechanics", Level = "Diploma", CourseArea = "Trades", Location = "Brisbane", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 14000m },
            new Course { CourseCode = "TRD60", CourseName = "Advanced Bricklaying", Level = "Certificate III", CourseArea = "Trades", Location = "Canberra", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 7000m },
            new Course { CourseCode = "TRD61", CourseName = "Building and Construction", Level = "Certificate IV", CourseArea = "Trades", Location = "Brisbane", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 9500m },
            new Course { CourseCode = "TRD62", CourseName = "Automotive Electrical Technology", Level = "Certificate III", CourseArea = "Trades", Location = "Melbourne", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 12000m },
            new Course { CourseCode = "TRD63", CourseName = "Painting and Decorating", Level = "Certificate III", CourseArea = "Trades", Location = "Adelaide", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 6000m },
            new Course { CourseCode = "TRD64", CourseName = "Advanced Metal Fabrication", Level = "Diploma", CourseArea = "Trades", Location = "Sydney", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 13500m },
            new Course { CourseCode = "TRD65", CourseName = "Refrigeration and Air Conditioning", Level = "Certificate IV", CourseArea = "Trades", Location = "Perth", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 14000m },
            new Course { CourseCode = "TRD66", CourseName = "Joinery", Level = "Certificate III", CourseArea = "Trades", Location = "Wollongong", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 6500m },
            new Course { CourseCode = "TRD67", CourseName = "Engineering Trades", Level = "Diploma", CourseArea = "Trades", Location = "Melbourne", StudyOption = "Part time", Duration = "24 months", EstimatedFee = 14500m },
            new Course { CourseCode = "TRD68", CourseName = "Advanced Electrical Control Systems", Level = "Graduate Certificate", CourseArea = "Trades", Location = "Canberra", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 8000m },
            new Course { CourseCode = "TRD69", CourseName = "Automotive Air Conditioning", Level = "Certificate II", CourseArea = "Trades", Location = "Sydney", StudyOption = "Full time", Duration = "6 months", EstimatedFee = 4000m },



            // Hospitality
            new Course { CourseCode = "HOSP01", CourseName = "Commercial Cookery", Level = "Certificate IV", CourseArea = "Hospitality", Location = "Adelaide", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 7000m },
            new Course { CourseCode = "HOSP02", CourseName = "Hotel Management", Level = "Diploma", CourseArea = "Hospitality", Location = "Sydney", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 12000m },
            new Course { CourseCode = "HOSP03", CourseName = "Bakery", Level = "Certificate III", CourseArea = "Hospitality", Location = "Melbourne", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 6500m },
            new Course { CourseCode = "HOSP04", CourseName = "Barista and Café Management", Level = "Certificate II", CourseArea = "Hospitality", Location = "Wollongong", StudyOption = "Self-paced", Duration = "6 months", EstimatedFee = 2800m },
            new Course { CourseCode = "HOSP05", CourseName = "Advanced Culinary Arts", Level = "Graduate Certificate", CourseArea = "Hospitality", Location = "Brisbane", StudyOption = "Full time", Duration = "9 months", EstimatedFee = 9500m },
            new Course { CourseCode = "HOSP06", CourseName = "Event Management Essentials", Level = "Diploma", CourseArea = "Hospitality", Location = "Sydney", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 8500m },
            new Course { CourseCode = "HOSP07", CourseName = "Patisserie", Level = "Certificate III", CourseArea = "Hospitality", Location = "Melbourne", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 6500m },
            new Course { CourseCode = "HOSP08", CourseName = "Advanced Wine and Beverage Studies", Level = "Graduate Certificate", CourseArea = "Hospitality", Location = "Adelaide", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 7200m },
            new Course { CourseCode = "HOSP09", CourseName = "Hospitality Management", Level = "Certificate IV", CourseArea = "Hospitality", Location = "Brisbane", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 9800m },
            new Course { CourseCode = "HOSP10", CourseName = "Hotel Operations and Guest Services", Level = "Diploma", CourseArea = "Hospitality", Location = "Sydney", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 11000m },
            new Course { CourseCode = "HOSP11", CourseName = "Bar Management", Level = "Certificate IV", CourseArea = "Hospitality", Location = "Perth", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 6200m },
            new Course { CourseCode = "HOSP12", CourseName = "Restaurant Entrepreneurship", Level = "Graduate Diploma", CourseArea = "Hospitality", Location = "Canberra", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 12500m },
            new Course { CourseCode = "HOSP13", CourseName = "Food and Beverage", Level = "Certificate II", CourseArea = "Hospitality", Location = "Sydney", StudyOption = "Full time", Duration = "6 months", EstimatedFee = 3000m },
            new Course { CourseCode = "HOSP14", CourseName = "Travel and Tourism Management", Level = "Diploma", CourseArea = "Hospitality", Location = "Melbourne", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 9000m },
            new Course { CourseCode = "HOSP15", CourseName = "Advanced Catering Services", Level = "Certificate IV", CourseArea = "Hospitality", Location = "Wollongong", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 7000m },


            // Creative Arts
            new Course { CourseCode = "CREA1", CourseName = "Introduction to Fashion Design", Level = "Certificate II", CourseArea = "Creative Arts", Location = "Melbourne", StudyOption = "Part time", Duration = "6 months", EstimatedFee = 3000m },
            new Course { CourseCode = "CREA2", CourseName = "Interior Design", Level = "Diploma", CourseArea = "Creative Arts", Location = "Sydney", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 11000m },
            new Course { CourseCode = "CREA3", CourseName = "Photography", Level = "Certificate IV", CourseArea = "Creative Arts", Location = "Adelaide", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 6500m },
            new Course { CourseCode = "CREA4", CourseName = "Fine Arts", Level = "Diploma", CourseArea = "Creative Arts", Location = "Brisbane", StudyOption = "Full time", Duration = "36 months", EstimatedFee = 28000m },
            new Course { CourseCode = "CREA5", CourseName = "Graphic Design", Level = "Certificate III", CourseArea = "Creative Arts", Location = "Canberra", StudyOption = "Self-paced", Duration = "9 months", EstimatedFee = 4000m },
            new Course { CourseCode = "CREA6", CourseName = "Digital Animation and 3D Modelling", Level = "Diploma", CourseArea = "Creative Arts", Location = "Brisbane", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 12000m },
            new Course { CourseCode = "CREA7", CourseName = "Acting and Performance", Level = "Certificate IV", CourseArea = "Creative Arts", Location = "Sydney", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 6500m },
            new Course { CourseCode = "CREA8", CourseName = "Music Production", Level = "Diploma", CourseArea = "Creative Arts", Location = "Melbourne", StudyOption = "Full time", Duration = "36 months", EstimatedFee = 28000m },
            new Course { CourseCode = "CREA9", CourseName = "Digital Illustration", Level = "Certificate III", CourseArea = "Creative Arts", Location = "Canberra", StudyOption = "Full time", Duration = "9 months", EstimatedFee = 5000m },
            new Course { CourseCode = "CREA10", CourseName = "Film and Television Studies", Level = "Diploma", CourseArea = "Creative Arts", Location = "Adelaide", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 11000m },
            new Course { CourseCode = "CREA11", CourseName = "Fine Arts", Level = "Diploma", CourseArea = "Creative Arts", Location = "Sydney", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 24000m },
            new Course { CourseCode = "CREA12", CourseName = "Game Art", Level = "Certificate IV", CourseArea = "Creative Arts", Location = "Brisbane", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 6500m },
            new Course { CourseCode = "CREA13", CourseName = "Advanced Photography Techniques", Level = "Diploma", CourseArea = "Creative Arts", Location = "Melbourne", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 7800m },
            new Course { CourseCode = "CREA14", CourseName = "Theatre Production and Stage Design", Level = "Diploma", CourseArea = "Creative Arts", Location = "Sydney", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 10000m },
            new Course { CourseCode = "CREA15", CourseName = "Creative Writing", Level = "Certificate III", CourseArea = "Creative Arts", Location = "Wollongong", StudyOption = "Self-paced", Duration = "9 months", EstimatedFee = 4000m },


            // Business and Administration
            new Course { CourseCode = "BUS101", CourseName = "Business Administration Basics", Level = "Diploma", CourseArea = "Business and Administration", Location = "Sydney", StudyOption = "Self-paced", Duration = "6 months", EstimatedFee = 2000m },
            new Course { CourseCode = "BUS201", CourseName = "Leadership", Level = "Certificate IV", CourseArea = "Business and Administration", Location = "Melbourne", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 4500m },
            new Course { CourseCode = "BUS301", CourseName = "Commerce", Level = "Diploma", CourseArea = "Business and Administration", Location = "Adelaide", StudyOption = "Full time", Duration = "36 months", EstimatedFee = 30000m },
            new Course { CourseCode = "BUS401", CourseName = "Graduate Diploma in Project Management", Level = "Graduate Diploma", CourseArea = "Business and Administration", Location = "Brisbane", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 12000m },
            new Course { CourseCode = "BUS501", CourseName = "Business Administration", Level = "Diploma", CourseArea = "Business and Administration", Location = "Canberra", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 35000m },
            new Course { CourseCode = "BUS601", CourseName = "Advanced Human Resource Management", Level = "Graduate Diploma", CourseArea = "Business and Administration", Location = "Sydney", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 12500m },
            new Course { CourseCode = "BUS602", CourseName = "Small Business Management", Level = "Certificate IV", CourseArea = "Business and Administration", Location = "Melbourne", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 4800m },
            new Course { CourseCode = "BUS603", CourseName = "International Business", Level = "Master", CourseArea = "Business and Administration", Location = "Canberra", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 33000m },
            new Course { CourseCode = "BUS604", CourseName = "Graduate Certificate in Logistics and Supply Chain", Level = "Graduate Certificate", CourseArea = "Business and Administration", Location = "Brisbane", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 9500m },
            new Course { CourseCode = "BUS605", CourseName = "Marketing and Communications", Level = "Certificate IV", CourseArea = "Business and Administration", Location = "Adelaide", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 5200m },
            new Course { CourseCode = "BUS606", CourseName = "Accounting", Level = "Diploma", CourseArea = "Business and Administration", Location = "Sydney", StudyOption = "Full time", Duration = "36 months", EstimatedFee = 30000m },
            new Course { CourseCode = "BUS607", CourseName = "E-Commerce", Level = "Diploma", CourseArea = "Business and Administration", Location = "Melbourne", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 10000m },
            new Course { CourseCode = "BUS608", CourseName = "Business Operations", Level = "Certificate III", CourseArea = "Business and Administration", Location = "Brisbane", StudyOption = "Part time", Duration = "9 months", EstimatedFee = 3500m },
            new Course { CourseCode = "BUS609", CourseName = "Graduate Diploma in Finance", Level = "Graduate Diploma", CourseArea = "Business and Administration", Location = "Sydney", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 12000m },
            new Course { CourseCode = "BUS610", CourseName = "Master of Entrepreneurship", Level = "Master", CourseArea = "Business and Administration", Location = "Canberra", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 34000m },
            new Course { CourseCode = "BUS611", CourseName = "Project Coordination", Level = "Certificate IV", CourseArea = "Business and Administration", Location = "Perth", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 4700m },
            new Course { CourseCode = "BUS612", CourseName = "Advanced Diploma in Strategic Leadership", Level = "Diploma", CourseArea = "Business and Administration", Location = "Sydney", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 11500m },


            // Agriculture
            new Course { CourseCode = "AG01", CourseName = "Agricultural Practices", Level = "Certificate III", CourseArea = "Agriculture", Location = "Regional NSW", StudyOption = "Full time", Duration = "9 months", EstimatedFee = 4200m },
            new Course { CourseCode = "AG02", CourseName = "Horticulture", Level = "Certificate IV", CourseArea = "Agriculture", Location = "Melbourne", StudyOption = "Part time", Duration = "12 months", EstimatedFee = 5500m },
            new Course { CourseCode = "AG03", CourseName = "Agribusiness", Level = "Diploma", CourseArea = "Agriculture", Location = "Brisbane", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 9000m },
            new Course { CourseCode = "AG04", CourseName = "Agricultural Science", Level = "Diploma", CourseArea = "Agriculture", Location = "Adelaide", StudyOption = "Full time", Duration = "36 months", EstimatedFee = 28000m },
            new Course { CourseCode = "AG05", CourseName = "Sustainable Farming Practices", Level = "Graduate Certificate", CourseArea = "Agriculture", Location = "Sydney", StudyOption = "Self-paced", Duration = "6 months", EstimatedFee = 7000m },
            new Course { CourseCode = "AG06", CourseName = "Rural Operations", Level = "Certificate II", CourseArea = "Agriculture", Location = "Regional NSW", StudyOption = "Full time", Duration = "9 months", EstimatedFee = 3000m },
            new Course { CourseCode = "AG07", CourseName = "Viticulture", Level = "Diploma", CourseArea = "Agriculture", Location = "Adelaide", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 8500m },
            new Course { CourseCode = "AG08", CourseName = "Graduate Certificate in Agricultural Economics", Level = "Graduate Certificate", CourseArea = "Agriculture", Location = "Canberra", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 9000m },
            new Course { CourseCode = "AG09", CourseName = "Wool Classing", Level = "Certificate IV", CourseArea = "Agriculture", Location = "Melbourne", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 5500m },
            new Course { CourseCode = "AG10", CourseName = "Animal Science", Level = "Diploma", CourseArea = "Agriculture", Location = "Sydney", StudyOption = "Full time", Duration = "36 months", EstimatedFee = 28000m },
            new Course { CourseCode = "AG11", CourseName = "Organic Farming", Level = "Diploma", CourseArea = "Agriculture", Location = "Regional QLD", StudyOption = "Full time", Duration = "18 months", EstimatedFee = 9000m },
            new Course { CourseCode = "AG12", CourseName = "Graduate Diploma in Crop Science", Level = "Graduate Diploma", CourseArea = "Agriculture", Location = "Brisbane", StudyOption = "Part time", Duration = "18 months", EstimatedFee = 11000m },
            new Course { CourseCode = "AG13", CourseName = "Agricultural Machinery", Level = "Certificate III", CourseArea = "Agriculture", Location = "Adelaide", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 6000m },
            new Course { CourseCode = "AG14", CourseName = "Aquaculture", Level = "Certificate IV", CourseArea = "Agriculture", Location = "Perth", StudyOption = "Full time", Duration = "12 months", EstimatedFee = 6500m },
            new Course { CourseCode = "AG15", CourseName = "Sustainable Agriculture", Level = "Diploma", CourseArea = "Agriculture", Location = "Canberra", StudyOption = "Full time", Duration = "24 months", EstimatedFee = 20000m }

            );
        }
    }
}
