﻿// <auto-generated />
using DAB2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAB2.Migrations
{
    [DbContext(typeof(HelpContext))]
    [Migration("20200331133014_Hel")]
    partial class Hel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAB2.Models.AssignmentModel", b =>
                {
                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherAuId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("TeacherAuId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("DAB2.Models.CourseModel", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DAB2.Models.ExerciseModel", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Lecture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("HelpWhere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentAuId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherAuId")
                        .HasColumnType("int");

                    b.HasKey("Number", "Lecture");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentAuId");

                    b.HasIndex("TeacherAuId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DAB2.Models.StudentAssignmentModel", b =>
                {
                    b.Property<int>("AuId")
                        .HasColumnType("int");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("StudentAssignmentModelId")
                        .HasColumnType("int");

                    b.HasKey("AuId", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("StudentAssignmentModel");
                });

            modelBuilder.Entity("DAB2.Models.StudentCourseModel", b =>
                {
                    b.Property<int>("AuId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentCourseModelId")
                        .HasColumnType("int");

                    b.HasKey("AuId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourseModel");
                });

            modelBuilder.Entity("DAB2.Models.StudentModel", b =>
                {
                    b.Property<int>("AuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DAB2.Models.TeacherModel", b =>
                {
                    b.Property<int>("AuId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DAB2.Models.AssignmentModel", b =>
                {
                    b.HasOne("DAB2.Models.CourseModel", "Courses")
                        .WithMany("Assignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB2.Models.TeacherModel", "Teachers")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherAuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAB2.Models.ExerciseModel", b =>
                {
                    b.HasOne("DAB2.Models.CourseModel", "Courses")
                        .WithMany("Exercises")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB2.Models.StudentModel", "Students")
                        .WithMany("Exercises")
                        .HasForeignKey("StudentAuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB2.Models.TeacherModel", "Teachers")
                        .WithMany("Exercises")
                        .HasForeignKey("TeacherAuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAB2.Models.StudentAssignmentModel", b =>
                {
                    b.HasOne("DAB2.Models.AssignmentModel", "Assignments")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB2.Models.StudentModel", "Students")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAB2.Models.StudentCourseModel", b =>
                {
                    b.HasOne("DAB2.Models.StudentModel", "Students")
                        .WithMany("StudentCourses")
                        .HasForeignKey("AuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAB2.Models.CourseModel", "Courses")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAB2.Models.TeacherModel", b =>
                {
                    b.HasOne("DAB2.Models.CourseModel", "Courses")
                        .WithMany("Teachers")
                        .HasForeignKey("AuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
