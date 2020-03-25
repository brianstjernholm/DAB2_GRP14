using System;
namespace DAB2.Models
{
    public class StudentAssignmentModel
    {
        // DEFINE SELF
        public int StudentAssignmentModelId { get; set; } //Key
        public string AuId { get; set; }
        public string AssignmentId { get; set; }

        // RELATIONS
        public StudentModel Students { get; set; }
        public AssignmentModel Assignments { get; set; }
    }
}
