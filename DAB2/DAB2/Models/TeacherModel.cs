using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAB2.Models
{
    public class TeacherModel
    {
        // DEFINE SELF
        [Key]
        public int AuId { get; set; } //Keys
        public string Name { get; set; }

        // RELATIONS
        public int CourseId { get; set; }
        public CourseModel Courses { get; set; }

        public List<ExerciseModel> Exercises { get; set; }
        public List<AssignmentModel> Assignments { get; set; }
    }
}
