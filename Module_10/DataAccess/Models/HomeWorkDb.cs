namespace DataAccess.Models
{
    public record HomeWorkDb : IIdPrpperty
    {
        public int Id { get; set; }
        public string? HWDescription { get; set; }
        public int? LectureId { get; set; }
        public LectureDb? Lecture { get; set; }

        //public LectorDb Lector { get; set; }
    }
}