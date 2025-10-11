using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseSearch.Data;
using CourseSearch.Models;

namespace CourseSearch.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly CourseDbContext _db;
        public CoursesController(CourseDbContext db)
        {
            _db = db;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? keyword, [FromQuery] string? location,
                                                [FromQuery] string? area, [FromQuery] string? studyOption)
        {
            IQueryable<Course> q = _db.Courses;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var k = keyword.Trim().ToLower();
                q = q.Where(c => c.CourseName.ToLower().Contains(k) || c.CourseCode.ToLower().Contains(k));
            }

            if (!string.IsNullOrWhiteSpace(location) && location.ToLower() != "any")
            {
                var loc = location.Trim().ToLower();
                q = q.Where(c => c.Location.ToLower().Contains(loc));
            }

            if (!string.IsNullOrWhiteSpace(area) && area.ToLower() != "any")
            {
                var a = area.Trim().ToLower();
                q = q.Where(c => c.CourseArea.ToLower().Contains(a));
            }

            if (!string.IsNullOrWhiteSpace(studyOption) && studyOption.ToLower() != "any")
            {
                var s = studyOption.Trim().ToLower();
                q = q.Where(c => c.StudyOption.ToLower().Contains(s));
            }

            var results = await q
                .OrderBy(c => c.CourseArea).ThenBy(c => c.CourseName)
                .ToListAsync();

            return Ok(results);
        }
    }
}
