using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAB2.Models
{
    public class AssignmentModel
    {
        // DEFINE SELF
        [Key]
        public int AssignmentId { get; set; }   //Key

        // RELATIONS
        public int TeacherAuId { get; set; }
        public TeacherModel Teachers { get; set; }

        public int CourseId { get; set; }
        public CourseModel Courses { get; set; }

        public virtual List<StudentAssignmentModel> StudentAssignments { get; set; }
    }
}
