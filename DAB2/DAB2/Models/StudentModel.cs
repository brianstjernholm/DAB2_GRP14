using System;
using System.Collections.Generic;

namespace DAB2.Models
{
    public class StudentModel
    {
        // DEFINE SELF
        public string AuId { get; set; } //Key
        public string Name { get; set; }

        // RELATIONS
        public List<ExerciseModel> Exercises { get; set; }
        public List<StudentAssignmentModel> StudentAssignments { get; set; }
        public List<StudentCourseModel> StudentCourses { get; set; }
    }
}
