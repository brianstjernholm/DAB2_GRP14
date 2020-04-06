using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAB2.Models
{
    public class TeacherModel
    {
        // DEFINE SELF
        //[Required]
        [Key]
        public int AuId { get; set; } //Key by annotation

        [Display(Name = "Teacher name")]
        public string Name { get; set; }

        // RELATIONS
        public int CourseId { get; set; }
        public CourseModel Course { get; set; }

        public List<ExerciseModel> Exercises { get; set; }
        public List<AssignmentModel> Assignments { get; set; }
    }
}
