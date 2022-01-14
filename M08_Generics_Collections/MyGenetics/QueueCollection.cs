namespace MyGenetics
{
    using System;
    using System.Collections;

    public class QueueCollection<T> : IEnumerable<T>
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
            var first = list[0];
            list.RemoveAt(0);
            Count--;
            return first;
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
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }
    }
}