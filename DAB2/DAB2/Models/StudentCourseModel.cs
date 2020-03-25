using System;
namespace DAB2.Models
{
    public class StudentCourseModel
    {
        // DEFINE SELF
        public int StudentCourseModelId { get; set; } //Key
        public string AuId { get; set; }
        public string CourseId { get; set; }
        public string Semester { get; set; }
        public string Active { get; set; }

        // RELATIONS
        public StudentModel Students { get; set; }
        public CourseModel Courses { get; set; }
    }
}





//Modelbuilder.Entity<StudentCourseModel>().HasOne=>(scm=>scm.Students).WithMany(sm=>sm.StudentCourses).HasForeignKey=>(scm=>scm.AuId)