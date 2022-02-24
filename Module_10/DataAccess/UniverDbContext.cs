namespace DataAccess
{
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    internal class UniverDbContext : DbContext
    {
        public DbSet<StudentDb> Students { get; set; }
        public DbSet<LectureDb> Lectures { get; set; }
        public DbSet<HomeWorkDb> HomeWorks{ get; set; }
        public DbSet<LectorDb> Lectors{ get; set; }

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

        //public UniverDbContext()
        //{
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Univer;Username=postgres;Password=123456");
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<StudentDb>().HasData(
        //        new StudentDb { Id = 1, Name = "Tom", Email = "Tom@email.com" },
        //        new StudentDb { Id = 2, Name = "Hary Potter", Email = "Harry@hogvards.uk" },
        //        new StudentDb { Id = 3, Name = "Pinocio", Email = "buratino@sherwood.uk" });
        //}
    }
}