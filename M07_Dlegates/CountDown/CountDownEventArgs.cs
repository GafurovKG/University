namespace M07_Delegates
{
    public class CountDownEventArgs : EventArgs
    {
        public CountDownEventArgs(string message, DateTime dateTime)
        {
            Message = message;
            DateTime = dateTime;
        }

        public string Message { get; set; }

        public DateTime DateTime { get; set; }
    }
}