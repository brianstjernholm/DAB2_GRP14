using System;
using System.Collections.Generic;

namespace DAB2.Models
{
    public class TeacherModel
    {
        // DEFINE SELF
        public string AuId { get; set; } //Keys
        public string Name { get; set; }

        // RELATIONS
        public string CourseId { get; set; }
        public CourseModel Courses { get; set; }

        public List<ExerciseModel> Exercises { get; set; }
        public List<AssignmentModel> Assignments { get; set; }
    }
}
