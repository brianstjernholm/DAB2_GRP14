using System;
using System.Collections.Generic;

namespace DAB2.Models
{
    public class CourseModel
    {
        // DEFINE SELF
        public int CourseId { get; set; }   //Key
        public string Name { get; set; }

        // RELATIONS
        public List<TeacherModel> Teachers { get; set; }
        public List<ExerciseModel> Exercises { get; set; }
        public List<AssignmentModel> Assignments { get; set; }
        public List<StudentCourseModel> StudentCourses { get; set; }
    }
}
