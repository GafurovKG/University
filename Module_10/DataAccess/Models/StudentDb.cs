namespace DataAccess.Models
{
    public record StudentDb : IIdPrpperty
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public string Email { get; set; } = null!;
        public string Tel { get; set; } = null!;
        public List<LectureDb> VisitedLectures { get; set; } = new();
        public List<AttendanceLog> AttendanceLog { get; set; } = new();
    }
}