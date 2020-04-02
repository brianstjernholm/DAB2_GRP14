﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DAB2.Models
{
    public class ExerciseModel
    {
        // DEFINE SELF
        //[Key]
        public string Lecture { get; set; } //Key by fluent; defined in context
        //[Key]
        public int Number { get; set; }     //Key by fluent; defined in context
        public string HelpWhere { get; set; }

        // RELATIONS
        public int TeacherAuId { get; set; }
        public TeacherModel Teachers { get; set; }

        public int StudentAuId { get; set; }
        public StudentModel Students { get; set; }

        public int CourseId { get; set; }
        public CourseModel Courses { get; set; }
    }
}
