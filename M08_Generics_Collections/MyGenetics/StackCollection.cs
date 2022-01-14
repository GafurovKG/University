namespace MyGenetics
{
    using System;
    using System.Collections;

    public class StackCollection<T> : IEnumerable<T>
    {
        private readonly List<T> list = new();

        public int Count { get; private set; }

        public void Enqueue(T newobject)
        {
            list.Add(newobject);
            Count++;
        }

        public T Dequeue()
        {
            var top = list[Count - 1];
            list.RemoveAt(Count - 1);
            Count--;
            return top;
        }

        public void ShowInfo()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item + " ");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[Count - i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            int iterator = 0;
            while (iterator < list.Count)
            {
                iterator++;
                yield return list[list.Count - iterator];
            }
        }
    }
}