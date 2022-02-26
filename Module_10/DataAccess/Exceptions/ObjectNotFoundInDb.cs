namespace DataAccess.Exceptions
{
    public class ObjectNotFoundInDb : Exception
    {
        public ObjectNotFoundInDb()
        {
        }

        public ObjectNotFoundInDb(string message)
            : base (message)
        {
        }

        public ObjectNotFoundInDb(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}