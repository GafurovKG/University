namespace M07_Delegates
{
    public class Subscriber1
    {
        private readonly string _name;
        private readonly DateTime _subscribeTime;

        public Subscriber1(string name)
        {
            _name = name;
        }

        public Subscriber1(string name, CountDown pub)
        {
            _name = name;
            _subscribeTime = DateTime.Now;
            pub.EventHappened += ActionOnAvent;
            Console.WriteLine($"{_name} подписался через конструктор в {_subscribeTime}");
            foreach (var item in pub.Events)
            {
                ActionOnAvent(pub, item);
            }
        }

        public void ActionOnAvent(object? sender, CountDownEventArgs e)
        {
            Console.WriteLine($"Код {_name} при срабатывании события... \n\tПолучено сообщение от события:\n\t\t{e.Message} в {e.DateTime}\n");
        }
    }
}