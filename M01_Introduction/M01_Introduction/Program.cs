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
            Console.WriteLine("Сортировка массива. Диапазон значений элементов массива от -100 до 100)");
            Random rnd = new Random();
            Console.Write("Укажите длину массива : ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(-100, 100);
            }

            Console.Write("\nИсходный массив: ");
            foreach (var item in array)
            {
                Console.Write(item + ", ");
            }
           
            Sort.sortASC(array, true); 
            Console.Write("\nМассив отсортированный по возрастанию: ");
            foreach (var item in array)
            {
                Console.Write(item + ", ");
            }
            Sort.sortASC(array, false);
            Console.Write("\nМассив отсортированный по убыванию: ");
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
            Console.WriteLine("\n\nСумма положительных элементов двумерного массива 3х3 с рандомным заполнением (нажмите Enter)");
            Console.ReadLine();
            Console.Write("Исходный двумерный массив: ");
            foreach (int item in array2)
            {
                Console.Write(item + ", ");
            }

            Console.Write("\nСумма положительных элементов массива: ");
            Console.WriteLine(Sum.sum(array2));

            //прямоугольник
            Console.WriteLine("\nРассчет параметров прямоугольника");
            Console.Write("Длина прямоугольника: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ширина прямоугольника: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Rectangl rect = new Rectangl(5, 10);
            Console.WriteLine("Площадь прямоугольника: " + rect.square());
            Console.WriteLine("Периметр прямоугольника: " + rect.perimetr());
        }
    
    }
}
