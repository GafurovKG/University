using System;
using System.Diagnostics;

namespace Performance
{
    internal class Program
    {
        private static void Main()
        {
            Process currentProcess = Process.GetCurrentProcess();
            var rdm = new Random();
            const int n = 1000000;

            long mem0 = currentProcess.PrivateMemorySize64;
            C[] classes = new C[n];
            long memCreateClassArray = currentProcess.PrivateMemorySize64 - mem0;

            for (int i = 0; i < n; i++)
            {
                classes[i] = new C { I = rdm.Next(n) };
            }

            long memInitClassArray = currentProcess.PrivateMemorySize64 - memCreateClassArray;

            S[] structs = new S[n];
            long memCreatStructArray = currentProcess.PrivateMemorySize64 - memInitClassArray;

            for (int i = 0; i < n; i++)
            {
                structs[i].I = rdm.Next(n);
            }

            long memInitStructArray = currentProcess.PrivateMemorySize64 - memCreatStructArray;

            Console.WriteLine("memCreateClassArray: " + memCreateClassArray);
            Console.WriteLine("memInitClassArray:" + memInitClassArray);
            Console.WriteLine("memCreatStructArray: " + memCreatStructArray);
            Console.WriteLine("memInitStructArray: " + memInitStructArray);

            var stopWatch = new Stopwatch();

            // время сортировки массива класса
            stopWatch.Start();
            Array.Sort(classes);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime ClassSort" + elapsedTime);
            stopWatch.Restart();

            // время сортировки массива структуры
            stopWatch.Start();
            Array.Sort(structs);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime Structort" + elapsedTime);
        }

        public class C : IComparable<C>
        {
            public int I { get; set; }

            int IComparable<C>.CompareTo(C other)
            {
                return this.I.CompareTo(other.I);
            }
        }

        public struct S : IComparable<S>
        {
            public int I { get; set; }

            int IComparable<S>.CompareTo(S other)
            {
                return this.I.CompareTo(other.I);
            }
        }
    }
}