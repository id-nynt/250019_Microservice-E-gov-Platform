using CourseSearch.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseSearch.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; } = null!;
    }
}