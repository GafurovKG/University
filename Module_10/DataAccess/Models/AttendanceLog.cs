namespace DataAccess.Models
{
    public class AttendanceLog
    {
        public int StudentId { get; set; }
        public StudentDb? Student { get; set;}
        public int LectureId { get; set; }
        public LectureDb? Lecture { get; set; }
        public int Mark { get; set; }
        public bool Visited { get; set; }
    }
}