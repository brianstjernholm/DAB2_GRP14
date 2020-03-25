using System;
namespace DAB2.Models
{
    public class StudentCourseModel
    {
        // DEFINE SELF
        public int StudentCourseModelId { get; set; } //Key
        public string Semester { get; set; }
        public string Active { get; set; }

        // RELATIONS
        public string AuId { get; set; }
        public StudentModel Students { get; set; }

        public string CourseId { get; set; }
        public CourseModel Courses { get; set; }
    }
}
