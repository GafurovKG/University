namespace DataAccess
{
    using DataAccess.Models;

    internal static class DefaultDB
    {
        public static void CreateDafaultDB(UniverDbContext studentContext)
        {
            studentContext.Database.EnsureDeleted();
            studentContext.Database.EnsureCreated();

            studentContext.Students.AddRange(
                new StudentDb { Name = "Hary Potter", Email = "Harry@hogvards.uk", Tel = "8800200600" },
                new StudentDb { Name = "Pinocio", Email = "buratino@sherwood.uk", Tel = "88002200660"});

            studentContext.Lectors.AddRange(
                new LectorDb { Name = "Dambldor", Email = "Dam@hogvards.uk" },
                new LectorDb { Name = "Leo Tolstoy", Email = "leo@ya_poliyna.ru" });
            studentContext.SaveChanges();
        }
    }
}