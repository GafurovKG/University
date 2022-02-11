namespace DataAccess.Models
{
    public record StudentDb : IIdPrpperty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public List<LectureDb> VisitedLectures { get; set; } = new();
        public List<AttendanceLog> AttendanceLog { get; set; } = new();
    }
}