using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext //tinfo200:[2021-03-11-kylelam-dykstra1] - Inheritance, School context will inherit from DbContext
    {
        //tinfo200:[2021-03-11-kylelam-dykstra1] - This will be the base constructor call, it doesn't do much
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        //tinfo200:[2021-03-11-kylelam-dykstra1] - The three entities that tells the framework to relate to each other. It will do it's magic for us
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        //tinfo200:[2021-03-11-kylelam-dykstra1] - This will tell the entity framework what we want to name the tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}