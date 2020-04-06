using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAB2.Models
{
    public class CourseModel
    {
        // DEFINE SELF
        //[Required]
        public int CourseModelId { get; set; } //Key by convention

        [Display(Name = "Course name")]
        public string Name { get; set; }

        // RELATIONS
        public List<TeacherModel> Teachers { get; set; }
        public List<ExerciseModel> Exercises { get; set; }
        public List<AssignmentModel> Assignments { get; set; }
        public List<StudentCourseModel> StudentCourses { get; set; }
    }
}
