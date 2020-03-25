using System;
namespace DAB2.Models
{
    public class ExerciseModel
    {
        // DEFINE SELF
        public string Lecture { get; set; } //Key
        public int Number { get; set; }     //Key
        public string HelpWhere { get; set; }

        // RELATIONS
        public TeacherModel Teachers { get; set; }
        public StudentModel Students { get; set; }
        public CourseModel Courses { get; set; }
    }
}
