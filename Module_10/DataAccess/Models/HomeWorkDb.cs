namespace DataAccess.Models
{
    public record HomeWorkDb :IIdPrpperty
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int LectureDbId { get; set; }
        public LectureDb? Lecture { get; set; }

        //public LectorDb Lector { get; set; }
    }
}