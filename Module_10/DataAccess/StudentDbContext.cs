namespace DataAccess
{
    using Microsoft.EntityFrameworkCore;

    internal class StudentDbContext : DbContext
    {
        public DbSet<StudentDb> Students { get; set; }
        public DbSet<LectureDb> Lecctures { get; set; }
        public DbSet<HomeWorkDb> HomeWorks{ get; set; }
        public DbSet<LectorDb> Lectors{ get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
    : base(options)
        {
        }

        //public StudentDbContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Univer;Username=postgres;Password=123456");
        //}
    }
}