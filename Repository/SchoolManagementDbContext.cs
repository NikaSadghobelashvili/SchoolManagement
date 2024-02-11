using DTO;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; } = null!;
        public DbSet<Grade> grades { get; set; } = null!;
        public DbSet<Subject> subjects { get; set; } = null!;
        public DbSet<School> schools { get; set; } = null!;
        public DbSet<Classroom> classrooms { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasIndex(u => u.PhoneNumber).IsUnique();
            modelBuilder.Entity<Subject>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<School>().HasIndex(sc => sc.SchoolName).IsUnique();

            modelBuilder.Entity<Classroom>()
             .Property(c => c.ClassroomId)
             .ValueGeneratedOnAdd();

            modelBuilder.Entity<Subject>()
           .HasMany(s => s.Grades)
           .WithOne(g => g.Subject)
           .HasForeignKey(g => g.SubjectId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
            .HasMany(s => s.Grades)
            .WithOne(g => g.Student)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Student>()
            .HasOne(s => s.school)
            .WithMany(sc => sc.students)
            .HasForeignKey(s => s.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}