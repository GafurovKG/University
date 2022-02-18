namespace DataAccess.Models
{
    public class AttendanceLog : IIdPrpperty
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentDb? Student { get; set;}
        public int LectureId { get; set; }
        public LectureDb? Lecture { get; set; }
        public int HomeWorkMark { get; set; }
    }
}