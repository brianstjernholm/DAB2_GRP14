using System;
namespace DAB2.Models
{
    public class StudentAssignmentModel
    {
        // DEFINE SELF
        public int StudentAssignmentModelId { get; set; } //Key
       
        // RELATIONS
        public int AuId { get; set; }
        public StudentModel Students { get; set; }

        public int AssignmentId { get; set; }
        public AssignmentModel Assignments { get; set; }
    }
}
