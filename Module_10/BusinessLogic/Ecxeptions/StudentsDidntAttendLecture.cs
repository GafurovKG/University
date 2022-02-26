namespace BusinessLogic.Exceptions
{
    public class StudentsDidntAttendLecture : Exception
    {
        public StudentsDidntAttendLecture()
        {
        }

        public StudentsDidntAttendLecture(string message)
            : base (message)
        {
        }

        public StudentsDidntAttendLecture(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}