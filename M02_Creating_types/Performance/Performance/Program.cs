using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;


namespace Performance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process currentProcess = Process.GetCurrentProcess();
            var rdm = new Random();
            const int n = 1000000;

            long mem0 = currentProcess.PrivateMemorySize64;
            C[] classes = new C[n];
            long memCreateClassArray = currentProcess.PrivateMemorySize64 - mem0;
            
            for (int i = 0; i < n; i++)
            {
                classes[i] = new C { i = rdm.Next(n) };
            }
            long memInitClassArray = currentProcess.PrivateMemorySize64 - memCreateClassArray;
            
            S[] structs = new S[n];
            long memCreatStructArray = currentProcess.PrivateMemorySize64 - memInitClassArray;

            for (int i = 0; i < n; i++)
            {
                structs[i].i = rdm.Next(n);
            }
            long memInitStructArray =currentProcess.PrivateMemorySize64 - memCreatStructArray;

            Console.WriteLine("memCreateClassArray: " + memCreateClassArray);
            Console.WriteLine("memInitClassArray:" + memInitClassArray);
            Console.WriteLine("memCreatStructArray: " + memCreatStructArray);
            Console.WriteLine("memInitStructArray: " + memInitStructArray);

            var stopWatch = new Stopwatch();
            //время сортировки массива класса
            stopWatch.Start();
            Array.Sort<C>(classes);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime ClassSort" + elapsedTime);
            stopWatch.Restart();

            //время сортировки массива структуры
            stopWatch.Start();
            Array.Sort<S>(structs);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime Structort" + elapsedTime);
        }
        public class C: IComparable<C>
        {
            public int i;

            int IComparable<C>.CompareTo(C other)
            {
                return this.i.CompareTo(other.i);
            }
        }
        public struct S : IComparable<S>
        {
            public int i;

            int IComparable<S>.CompareTo(S other)
            {
                return this.i.CompareTo(other.i);
            }
        }
    }
}
