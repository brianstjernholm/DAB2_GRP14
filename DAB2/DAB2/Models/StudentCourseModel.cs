using System;
namespace DAB2.Models
{
    public class StudentCourseModel
    {
        // DEFINE SELF
        //public int StudentCourseModelId { get; set; } //Key by convention
        public string Semester { get; set; }
        public string Active { get; set; }

        // RELATIONS
        public int AuId { get; set; }
        public StudentModel Students { get; set; }

        public int CourseId { get; set; }
        public CourseModel Courses { get; set; }
    }
}
