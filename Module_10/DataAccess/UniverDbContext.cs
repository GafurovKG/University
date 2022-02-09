namespace DataAccess
{
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    internal class UniverDbContext : DbContext
    {
        public DbSet<StudentDb> Students { get; set; }
        public DbSet<LectureDb> Lecctures { get; set; }
        public DbSet<HomeWorkDb> HomeWorks{ get; set; }
        public DbSet<LectorDb> Lectors{ get; set; }

        public UniverDbContext(DbContextOptions<UniverDbContext> options)
    : base(options)
        {
        }

        //public StudentDbContext()
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