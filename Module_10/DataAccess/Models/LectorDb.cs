namespace DataAccess.Models
{
    public record LectorDb : IIdPrpperty
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Email { get; set; } = null!;

        // public List<LectureDb> Lectures { get; set; } = new();
    }
}