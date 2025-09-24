using System.ComponentModel.DataAnnotations;

namespace CourseSearch.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseCode { get; set; } = "";
        public string CourseName { get; set; } = "";
        public string Level { get; set; } = "";
        public string CourseArea { get; set; } = "";
        public string Location { get; set; } = "";
        public string StudyOption { get; set; } = "";
        public string Duration { get; set; } = "";
        public decimal EstimatedFee { get; set; }
    }
}