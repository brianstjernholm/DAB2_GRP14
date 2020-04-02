using System;
using System.ComponentModel.DataAnnotations;

namespace DAB2.Models
{
    public class StudentAssignmentModel
    {
        // DEFINE SELF
        [Key]
        public int StudentAssignmentModelId { get; set; } //Key

        // RELATIONS
        public int AuId { get; set; }
        public StudentModel Students { get; set; }

        public int AssignmentId { get; set; }
        public virtual AssignmentModel Assignments { get; set; }
    }
}
