using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAB2.Models
{
    public class StudentModel
    {
        // DEFINE SELF
        [Required]
        [Key]
        public int AuId { get; set; } //Key by annotation
        public string Name { get; set; }

        // RELATIONS
        public List<ExerciseModel> Exercises { get; set; }
        public List<StudentAssignmentModel> StudentAssignments { get; set; }
        public List<StudentCourseModel> StudentCourses { get; set; }
    }
}
