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
        public TeacherModel Teacher { get; set; }

        public int CourseId { get; set; }
        public CourseModel Course { get; set; }

        public virtual List<StudentAssignmentModel> StudentAssignments { get; set; }
    }
}
