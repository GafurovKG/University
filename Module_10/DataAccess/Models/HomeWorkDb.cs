namespace DataAccess.Models
{
    public record HomeWorkDb : IIdPrpperty
    {
        public int Id { get; init; }
        public string HWDescription { get; set; } = null!;
        public int? LectureId { get; set; }
        public LectureDb? Lecture { get; set; }
    }
}