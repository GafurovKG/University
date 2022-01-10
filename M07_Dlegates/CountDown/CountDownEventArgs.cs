namespace M07_Delegates
{
    public class CountDownEventArgs : EventArgs
    {
        public CountDownEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}