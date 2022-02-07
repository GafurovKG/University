namespace DataAccess
{
    using Microsoft.EntityFrameworkCore;

    internal class StudentDbContext : DbContext
    {
        public DbSet<StudentDb> Students { get; set; }

        public StudentDbContext()
        {

        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Univer;Username=postgres;Password=123456");
        }
    }
}