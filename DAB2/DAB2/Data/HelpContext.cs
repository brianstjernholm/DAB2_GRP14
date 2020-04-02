using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAB2.Models;

namespace DAB2.Data
{
    public class HelpContext : DbContext
    {
        public HelpContext(DbContextOptions<HelpContext> options)
            : base(options)
        {
        }

        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<AssignmentModel> Assignments { get; set; }
        public DbSet<ExerciseModel> Exercises { get; set; }

        public DbSet<DAB2.Models.StudentAssignmentModel> StudentAssignmentModel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Defining composite key
            modelBuilder.Entity<ExerciseModel>().HasKey(em => new { em.Number, em.Lecture });

            // Defining composite key (SHADOW TABLE: STUDENTASSIGNMENTMODEL)
            modelBuilder.Entity<StudentAssignmentModel>().HasKey(sam => new { sam.AssignmentId, sam.AuId });

            // Defining composite key (SHADOW TABLE: STUDENTCOURSEMODEL)
            modelBuilder.Entity<StudentCourseModel>().HasKey(scm => new { scm.CourseId, scm.AuId });
        }

    }

}
