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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AFL2;Integrated Security=True");
        }

        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<AssignmentModel> Assignments { get; set; }
        public DbSet<ExerciseModel> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // STUDENT MODEL
            modelBuilder.Entity<StudentModel>().HasKey(sm => sm.AuId);
            //-> One To Many - Exercise
            modelBuilder.Entity<StudentModel>()
                .HasMany<ExerciseModel>(em => em.Exercises)
                .WithOne(sm => sm.Students)
                .HasForeignKey(em => new { em.Number, em.Lecture }); //-> a.number og a.lecture skal være KEYS, nuværende løsning er sikkert ikke korrekt.

            //-> Many To Many - Assignment
            modelBuilder.Entity<StudentAssignmentModel>().HasKey(sam => new { sam.AuId, sam.AssignmentId });
            modelBuilder.Entity<StudentAssignmentModel>()
                .HasOne(sam => sam.Students)
                .WithMany(sm => sm.StudentAssignments)
                .HasForeignKey(sam => sam.AuId);
            modelBuilder.Entity<StudentAssignmentModel>()
                .HasOne(sam => sam.Assignments)
                .WithMany(am => am.StudentAssignments)
                .HasForeignKey(sam => sam.AssignmentId);

            //-> Many To Many - Course
            modelBuilder.Entity<StudentCourseModel>().HasKey(scm => new { scm.AuId, scm.CourseId });
            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(scm => scm.Students)
                .WithMany(sm => sm.StudentCourses)
                .HasForeignKey(scm => scm.AuId);
            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(scm => scm.Courses)
                .WithMany(cm => cm.StudentCourses)
                .HasForeignKey(scm => scm.CourseId);




            // EXERRCISE MODEL
                modelBuilder.Entity<ExerciseModel>().HasKey(em => new { em.Number, em.Lecture });
            //-> Many To One - Student
            modelBuilder.Entity<ExerciseModel>()
                .HasOne(em => em.Students)
                .WithMany(sm => sm.Exercises)
                .HasForeignKey(em => em.StudentAuId);

            //-> Many To One - Teacher
            modelBuilder.Entity<ExerciseModel>()
                .HasOne(em => em.Teachers)
                .WithMany(tm => tm.Exercises)
                .HasForeignKey(em => em.TeacherAuId);

            //-> Many To One - Course
            modelBuilder.Entity<ExerciseModel>()
                .HasOne(em => em.Courses)
                .WithMany(cm => cm.Exercises)
                .HasForeignKey(em => em.CourseId);





            // TEACHER MODEL
            modelBuilder.Entity<TeacherModel>().HasKey(tm => tm.AuId);
            //-> Many To One - Course
            modelBuilder.Entity<TeacherModel>()
                .HasOne(tm => tm.Courses)
                .WithMany(cm => cm.Teachers)
                .HasForeignKey(tm => tm.CourseId);

            //-> One To Many - Assignment
            modelBuilder.Entity<TeacherModel>()
                .HasMany<AssignmentModel>(am => am.Assignments)
                .WithOne(tm => tm.Teachers)
                .HasForeignKey(am => am.TeacherAuId);

            //-> One To Many - Exercise
            modelBuilder.Entity<TeacherModel>()
                .HasMany<ExerciseModel>(em => em.Exercises)
                .WithOne(tm => tm.Teachers)
                .HasForeignKey(em => em.TeacherAuId);





            // ASSIGNMENT MODEL
            modelBuilder.Entity<AssignmentModel>().HasKey(am => am.AssignmentId);
            //-> Many To One - Course
            modelBuilder.Entity<AssignmentModel>()
                .HasOne(am => am.Courses)
                .WithMany(cm => cm.Assignments)
                .HasForeignKey(am => am.CourseId);

            //-> Many To One - Teacher
            modelBuilder.Entity<AssignmentModel>()
                .HasOne(am => am.Teachers)
                .WithMany(tm => tm.Assignments)
                .HasForeignKey(am => am.TeacherAuId);

            //-> Many To Many - Student
            modelBuilder.Entity<StudentAssignmentModel>().HasKey(sam => new { sam.AuId, sam.AssignmentId });
            modelBuilder.Entity<StudentAssignmentModel>()
                .HasOne(sam => sam.Students)
                .WithMany(sm => sm.StudentAssignments)
                .HasForeignKey(sam => sam.AuId);
            modelBuilder.Entity<StudentAssignmentModel>()
                .HasOne(sam => sam.Assignments)
                .WithMany(am => am.StudentAssignments)
                .HasForeignKey(sam => sam.AssignmentId);




            // COURSE MODEL
            modelBuilder.Entity<CourseModel>().HasKey(cm => cm.CourseId);
            //-> Many To Many - Student
            modelBuilder.Entity<StudentCourseModel>().HasKey(scm => new { scm.AuId, scm.CourseId });
            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(scm => scm.Students)
                .WithMany(sm => sm.StudentCourses)
                .HasForeignKey(scm => scm.AuId);
            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(scm => scm.Courses)
                .WithMany(cm => cm.StudentCourses)
                .HasForeignKey(scm => scm.CourseId);

            //-> One To Many - Assignment
            modelBuilder.Entity<CourseModel>()
                .HasMany<AssignmentModel>(am => am.Assignments)
                .WithOne(cm => cm.Courses)
                .HasForeignKey(am => am.AssignmentId);

            //-> One To Many - Teacher
            modelBuilder.Entity<CourseModel>()
                .HasMany<TeacherModel>(tm => tm.Teachers)
                .WithOne(cm => cm.Courses)
                .HasForeignKey(am => am.AuId);
        }

    }

}
