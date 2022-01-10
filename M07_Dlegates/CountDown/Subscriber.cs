namespace M07_Delegates
{
    public class Subscriber
    {
        private readonly string _id;

        public Subscriber(string id, CountDown pub)
        {
            _id = id;
            pub.RaiseCustomEvent += HandleCustomEvent;
            Console.WriteLine($"{_id} подписался в {DateTime.Now}");
        }

        private void HandleCustomEvent(object sender, CountDownEventArgs e)
        {
            Console.WriteLine($"Код подписчика {_id} при срабатывании события: \n\tПодписчик получил сообщение от события:\n\t\t{e.Message}\n");
        }
    }
}