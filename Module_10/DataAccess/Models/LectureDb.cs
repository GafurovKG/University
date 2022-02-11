namespace DataAccess.Models
{
    public record LectureDb : IIdPrpperty
    {
        public int Id { get; set; }
        public string? Theme { get; set; }
        public HomeWorkDb? HomeWork { get; set; }
        public int LectorDbID { get; set; }
        public LectorDb? Lector { get; set; }
        public List<StudentDb> VisitedStudents { get; set; } = new();
        public List<AttendanceLog> AttendanceLog { get; set; } = new();
    }
}