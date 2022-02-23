namespace DataAccess.Models
{
    public record AttendanceLog
    {
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

        public int StudentId { get; set; }
        public StudentDb? Student { get; set; }
        public int LectureId { get; set; }
        public LectureDb? Lecture { get; set; }
        public int? HomeWorkMark { get; set; }
    }
}