namespace DataAccess
{
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    internal class UniverDbContext : DbContext
    {
        public DbSet<StudentDb> Students { get; set; } = null!;
        public DbSet<LectureDb> Lectures { get; set; } = null!;
        public DbSet<HomeWorkDb> HomeWorks { get; set; } = null!;
        public DbSet<LectorDb> Lectors { get; set; } = null!;

        public UniverDbContext(DbContextOptions<UniverDbContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LectureDb>()
                .HasOne(l => l.HomeWork).WithOne(hw => hw.Lecture)
                .HasForeignKey<HomeWorkDb>(hw => hw.LectureId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder
            .Entity<LectureDb>()
            .HasMany(s => s.VisitedStudents)
            .WithMany(l => l.VisitedLectures)
            .UsingEntity<AttendanceLog>(
               j => j
                .HasOne(pt => pt.Student)
                .WithMany(t => t.AttendanceLog)
                .HasForeignKey(pt => pt.StudentId),
               j => j
                .HasOne(pt => pt.Lecture)
                .WithMany(p => p.AttendanceLog)
                .HasForeignKey(pt => pt.LectureId),
               j =>
            {
                j.Property(pt => pt.HomeWorkMark).HasDefaultValue(0);
                j.HasKey(t => new { t.LectureId, t.StudentId });
                j.ToTable("AttendanceLog");
            });
        }
    }
}