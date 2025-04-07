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
        public DbSet<Department> Departments { get; set; } = default!;
        public DbSet<Instructor> Instructors { get; set; } = default!;
        public DbSet<OfficeAssigment> OfficeAssigments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable(nameof(Course))
                .HasMany(c => c.Instructors)
                .WithMany(i => i.Courses);
            modelBuilder.Entity<Instructor>().ToTable(nameof(Instructor));
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
        }

    }
}
