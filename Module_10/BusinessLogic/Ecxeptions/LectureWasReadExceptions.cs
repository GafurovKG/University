namespace BusinessLogic.Exceptions
{
    public class LectureWasReadExceptions : Exception
    {
        public LectureWasReadExceptions()
        {
        }

        public LectureWasReadExceptions(string message)
            : base(message)
        {
        }

        public LectureWasReadExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}