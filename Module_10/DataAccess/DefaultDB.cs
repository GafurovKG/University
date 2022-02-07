namespace DataAccess
{
    internal static class DefaultDB
    {
        public static void CreateDafaultDB(StudentDbContext studentContext)
        {
            studentContext.Database.EnsureDeleted();
            studentContext.Database.EnsureCreated();

            studentContext.Students.AddRange(
                new StudentDb { Name = "Hary Potter", Email = "Harry@hogvards.uk" },
                new StudentDb { Name = "Pinocio", Email = "buratino@sherwood.uk" });
            studentContext.SaveChanges();
        }
    }
}