namespace MyGenetics
{
    public static class Calculator
    {
        public static double PolishCalulate(string input)
        {
            if (input == string.Empty || input == null)
            {
                return 0;
            }

            var stack = new StackCollection<double>();
            var queue = new QueueCollection<char>();
            foreach (var item in input)
            {
                if (char.IsDigit(item))
                {
                    queue.Enqueue(item);
                }
                else if (item.Equals(' '))
                {
                    string number = string.Empty;
                    foreach (var digit in queue)
                    {
                        number += queue.Dequeue();
                    }

                    if (number != string.Empty)
                    {
                        stack.Enqueue(Convert.ToInt32(number));
                    }
                }
                else if (item == '+')
                {
                    stack.Enqueue(stack.Dequeue() + stack.Dequeue());
                }
                else if (item == '-')
                {
                    stack.Enqueue(-stack.Dequeue() + stack.Dequeue());
                }
                else if (item == '*')
                {
                    stack.Enqueue(stack.Dequeue() * stack.Dequeue());
                }
                else if (item == '/')
                {
                    stack.Enqueue(1 / stack.Dequeue() * stack.Dequeue());
                }
            }

            return Math.Round(stack.Dequeue(), 1);
        }
    }
}