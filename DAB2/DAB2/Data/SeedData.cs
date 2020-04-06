using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAB2.Data;
using DAB2.Models;

namespace DAB2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HelpContext(serviceProvider.GetRequiredService<DbContextOptions<HelpContext>>()))
            {
                // Look for any movies.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                var studentVictor = new StudentModel
                {
                    Name = "Victor"
                };
                context.Students.AddRange(studentVictor);

                var courseDab = new CourseModel 
                { 
                    Name = "DAB" 
                };
                context.Courses.AddRange(courseDab);


                var teacherHenrik = new TeacherModel
                {
                    Name = "Henrik",
                    Course = courseDab
                };
                context.Teachers.AddRange(teacherHenrik);

                var assignmentDab = new AssignmentModel
                {
                    Course = courseDab,
                    Teacher = teacherHenrik
                };
                context.Assignments.AddRange(assignmentDab);

                context.StudentAssignmentModel.AddRange(new StudentAssignmentModel
                {
                    Assignment = assignmentDab,
                    Student = studentVictor
                });

                context.SaveChanges();
            }
        }
    }
}


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                