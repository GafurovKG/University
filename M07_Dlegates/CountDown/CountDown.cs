namespace M07_Delegates
{
    public class CountDown
    {
        public event EventHandler<CountDownEventArgs> RaiseCustomEvent;

        public void SomeFunc()
        {
            Console.WriteLine("Код перед событием...");
            OnRaiseCustomEvent(new CountDownEventArgs("Событие сработало"));
        }

        protected virtual void OnRaiseCustomEvent(CountDownEventArgs e)
        {
            EventHandler<CountDownEventArgs> raiseEvent = RaiseCustomEvent;

            if (raiseEvent != null)
            {
                e.Message += $" в {DateTime.Now}";
                raiseEvent(this, e);
            }
        }
    }
}