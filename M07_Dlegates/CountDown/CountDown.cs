namespace M07_Delegates
{
    public class CountDown
    {
        public event EventHandler<CountDownEventArgs>? EventHappened;

        public List<CountDownEventArgs> Events { get; set; }

        public CountDown()
        {
            Events = new List<CountDownEventArgs>();
        }

        public void SomeFunc()
        {
            // Thread.Sleep(2000);
            Console.WriteLine($"\nВремя срабатывания события: {DateTime.Now}\n");

            EventHandler<CountDownEventArgs>? raiseEvent = EventHappened;
            var eventArgs = new CountDownEventArgs("Событие сработало", DateTime.Now);
            raiseEvent?.Invoke(this, eventArgs);
            Events.Add(eventArgs);
        }

        // Паблишер сам вызывает реакцию на событие у подписавшихся через этот метод
        public void SubscribeOnMe(EventHandler<CountDownEventArgs> subscriber, string subName)
        {
            Console.WriteLine($"{subName} подписался через метод в CountDown в  {DateTime.Now}");
            EventHappened += subscriber;
            foreach (var item in Events)
            {
                if (DateTime.Now > item.DateTime)
                {
                    subscriber(this, item);
                }
            }
        }
    }
}