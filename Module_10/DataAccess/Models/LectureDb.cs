namespace DataAccess.Models
{
    public record LectureDb : IIdPrpperty
    {
        public int Id { get; set; }
        public string? LectureTheme { get; set; }
        public HomeWorkDb? HomeWork { get; set; }
        public List<StudentDb> VisitedStudents { get; set; } = new();
        public List<AttendanceLog> AttendanceLog { get; set; } = new();
    }
}