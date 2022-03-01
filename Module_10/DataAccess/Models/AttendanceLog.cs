namespace DataAccess.Models
{
    public record AttendanceLog
    {
        public int StudentId { get; set; }
        public StudentDb Student { get; set; } = null!;
        public int LectureId { get; set; }
        public LectureDb Lecture { get; set; } = null!;
        public int HomeWorkMark { get; set; }

        public AttendanceLog(AttendanceLog inst)
        {
            this.Student = inst.Student;
            this.StudentId = inst.StudentId;
            this.Lecture = inst.Lecture;
            this.StudentId = inst.LectureId;
            this.HomeWorkMark = inst.HomeWorkMark;
        }

        public AttendanceLog()
        {
        }
    }
}