using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAB2.Models
{
    public class HelpRequestModel
    {
        [Key]
        public int HelpRequestId { get; set; }

        public StudentModel student { get; set; }

        public TeacherModel teacher { get; set; }

        public CourseModel course { get; set; }

        public AssignmentModel assignment { get; set; }

        public ExerciseModel exercise { get; set; }

    }
}
