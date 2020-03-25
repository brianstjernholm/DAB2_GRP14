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
            modelBuilder.Entity<StudentModel>().HasKey(b => b.AuId);
            //-> One To Many - Exercise
            modelBuilder.Entity<StudentModel>()
                .HasMany<ExerciseModel>(b => b.Exercises)
                .WithOne(r => r.Students)
                .HasForeignKey(a => a.Number + a.Lecture);   //-> a.number og a.lecture skal være KEYS, nuværende løsning er sikkert ikke korrekt.

            //-> Many To Many - Assignment
            modelBuilder.Entity<StudentAssignmentModel>().HasKey(sam => new { sam.AuId, sam.AssignmentId });
            modelBuilder.Entity<StudentAssignmentModel>()
                .HasOne(sam => sam.Students)
                .WithMany(sm => sm.StudentAssignments)
                .HasForeignKey(plb => plb.AuId);
            modelBuilder.Entity<StudentAssignmentModel>()
                .HasOne(plb => plb.Assignments)
                .WithMany(b => b.StudentAssignments)
                .HasForeignKey(plb => plb.AssignmentId);

            //-> RIGTIG!
            //-> Many To Many - Course
            modelBuilder.Entity<StudentCourseModel>().HasKey(a => new { a.AuId, a.CourseId });
            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(scm => scm.Students)
                .WithMany(sm => sm.StudentCourses)
                .HasForeignKey(scm => scm.AuId);
            modelBuilder.Entity<StudentCourseModel>()
                .HasOne(scm => scm.Courses)
                .WithMany(cm => cm.StudentCourses)
                .HasForeignKey(scm => scm.CourseId);
        }







    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    // RESTAURANT MODEL
    //    modelBuilder.Entity<RestaurantModel>().HasKey(b => b.Address);
    //    //-> One To Many - Review
    //    modelBuilder.Entity<RestaurantModel>()
    //        .HasMany<ReviewModel>(b => b.Reviews)
    //        .WithOne(r => r.Restaurants)
    //        .HasForeignKey(r => r.RestaurantAddress);
    //    //-> One To Many - Table
    //    modelBuilder.Entity<RestaurantModel>()
    //        .HasMany<TableModel>(b => b.Tables)
    //        .WithOne(r => r.Restaurants)
    //        .HasForeignKey(r => r.RestaurantAddress);
    //    //-> Many To Many - Dish (RestaurantDish)
    //    modelBuilder.Entity<RestaurantDishModel>().HasKey(p => new { p.RestaurantAddress, p.DishName });
    //    modelBuilder.Entity<RestaurantDishModel>()
    //        .HasOne(plb => plb.Restaurants)
    //        .WithMany(b => b.RestaurantDishes)
    //        .HasForeignKey(plb => plb.RestaurantAddress);
    //    modelBuilder.Entity<RestaurantDishModel>()
    //        .HasOne(plb => plb.Dishes)
    //        .WithMany(b => b.RestaurantDishes)
    //        .HasForeignKey(plb => plb.DishName);

    //    // PERSON MODEL
    //    modelBuilder.Entity<PersonModel>().HasKey(p => p.PersonId);
    //    //-> One To One - Waiter
    //    modelBuilder.Entity<PersonModel>()
    //        .HasOne(p => p.Waiter)
    //        .WithOne(w => w.Person)
    //        .HasForeignKey<WaiterModel>();
    //    //-> One To One - Guest
    //    modelBuilder.Entity<PersonModel>()
    //        .HasOne(p => p.Guest)
    //        .WithOne(g => g.Person)
    //        .HasForeignKey<GuestModel>();

    //    // GUEST MODEL
    //    modelBuilder.Entity<GuestModel>().HasKey(g => g.Name);
    //    //-> Many To One - Table
    //    modelBuilder.Entity<GuestModel>()
    //        .HasOne(g => g.Tables)
    //        .WithMany(t => t.Guests)
    //        .HasForeignKey(g => g.TableNumber);
    //    //-> Many To One - Review
    //    modelBuilder.Entity<GuestModel>()
    //        .HasOne(g => g.Reviews)
    //        .WithMany(r => r.Guests)
    //        .HasForeignKey(g => g.ReviewText);
    //    //-> Many To Many - Dish
    //    modelBuilder.Entity<GuestDishModel>().HasKey(a => new { a.GuestName, a.DishName });
    //    modelBuilder.Entity<GuestDishModel>()
    //        .HasOne(gd => gd.Guests)
    //        .WithMany(g => g.GuestDish)
    //        .HasForeignKey(gd => gd.GuestName);
    //    modelBuilder.Entity<GuestDishModel>()
    //        .HasOne(gd => gd.Dishes)
    //        .WithMany(d => d.GuestDish)
    //        .HasForeignKey(gd => gd.DishName);

    //    // WAITER MODEL
    //    modelBuilder.Entity<WaiterModel>().HasKey(w => w.Id);
    //    //-> Many To Many - Table
    //    modelBuilder.Entity<WaiterTableModel>().HasKey(a => new { a.WaiterId, a.TableNumber });
    //    modelBuilder.Entity<WaiterTableModel>()
    //        .HasOne(wt => wt.Waiters)
    //        .WithMany(w => w.WaiterTable)
    //        .HasForeignKey(wt => wt.WaiterId);
    //    modelBuilder.Entity<WaiterTableModel>()
    //        .HasOne(wt => wt.Tables)
    //        .WithMany(t => t.WaiterTable)
    //        .HasForeignKey(wt => wt.TableNumber);

    //    // REVIEW MODEL
    //    modelBuilder.Entity<ReviewModel>().HasKey(r => r.Text);
    //    //-> One To Many - Dish
    //    modelBuilder.Entity<ReviewModel>()
    //        .HasMany<DishModel>(r => r.Dishes)
    //        .WithOne(d => d.Reviews)
    //        .HasForeignKey(d => d.ReviewText);

    //    // DISH MODEL
    //    modelBuilder.Entity<DishModel>().HasKey(d => d.Name);

    //    // TABLE MODEL
    //    modelBuilder.Entity<TableModel>().HasKey(t => t.TableId);

    }

}
