namespace DataAccess.Models
{
    public record LectureDb : IIdPrpperty
    {
        public int Id { get; init; }
        public string LectureTheme { get; set; } = null!;
        public HomeWorkDb? HomeWork { get; set; }
        public List<StudentDb> VisitedStudents { get; set; } = new();
        public List<AttendanceLog> AttendanceLog { get; set; } = new();
        public bool IsReaded { get; set; }
    }
}