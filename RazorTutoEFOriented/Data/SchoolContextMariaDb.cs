using Microsoft.EntityFrameworkCore;
using RazorTutoEFOriented.Models;

namespace RazorTutoEFOriented.Data
{
    public class SchoolContextMariaDb : DbContext
    {
        public SchoolContextMariaDb (DbContextOptions<SchoolContextMariaDb> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Enrollment> Enrollments { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
