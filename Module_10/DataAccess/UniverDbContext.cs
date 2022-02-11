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
            //modelBuilder
            //    .Entity<LectureDb>()
            //    .HasOne(u => u.HomeWork)
            //    .WithOne(p => p.Lecture)
            //    .HasForeignKey<HomeWorkDb>(p => p.LectureDbId);

            modelBuilder.Entity<LectureDb>()
                .HasOne(u => u.HomeWork).WithOne(p => p.Lecture)
                .HasForeignKey<HomeWorkDb>(up => up.Id).IsRequired();
            modelBuilder.Entity<LectureDb>().ToTable("LecturesAndHomeWorks");
            modelBuilder.Entity<HomeWorkDb>().ToTable("LecturesAndHomeWorks");

            modelBuilder
            .Entity<LectureDb>()
            .HasMany(c => c.VisitedStudents)
            .WithMany(s => s.VisitedLectures)
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
                j.Property(pt => pt.Mark).HasDefaultValue(null);
                j.HasKey(t => new { t.LectureId, t.StudentId });
                j.ToTable("AttendanceLog");
            });

            //modelBuilder.Entity<StudentDb>()
            //    .HasMany(c => c.VisitedLectures)
            //    .WithMany(s => s.VisitedStudents)
            //    .UsingEntity(j => j.ToTable("AttendanceLog"));
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