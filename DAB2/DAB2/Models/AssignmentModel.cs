﻿using System;
using System.Collections.Generic;

namespace DAB2.Models
{
    public class AssignmentModel
    {
        // DEFINE SELF
        public int AssignmentId { get; set; }   //Key

        // RELATIONS
        public TeacherModel Teachers { get; set; }
        public CourseModel Courses { get; set; }
        public List<StudentAssignmentModel> StudentAssignments { get; set; }
    }
}