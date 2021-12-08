using System;
using ArrayHelper;
using RectangleHelper;
using System.IO;

namespace M01_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание массива для Sort
            Random rnd = new Random();
            Console.WriteLine("Укажите размер массива: ");
            int n = Convert.ToInt32(Console.ReadLine());


            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-10, 10);
            }


            Console.Write("\nИсходный массив: ");
            foreach (var item in array)
            {
                Console.Write(item + ", ");
            }
            // Сортировка массива в выбранном направлении
            Sort.sortASC(array); 

            Console.Write("\nCортированный массив: ");
            foreach (var item in array)
            {
                Console.Write(item + ", ");
            }

            // Сумма двумерного массива

            int[,] array2 = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array2[i, j] = rnd.Next(-10, 10);
                }
            }
            Console.Write("\nИсходный двумерный массив: ");
            foreach (int item in array2)
            {
                Console.Write(item + ", ");
            }

            Console.Write("\nСумма положительных элементов массива: ");
            Console.WriteLine(Sum.sum(array2));

            //прямоугольник
            Console.WriteLine("Длина прямоугольника: ");
            
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nШирина прямоугольника: ");

        }
            
        

    }
}
