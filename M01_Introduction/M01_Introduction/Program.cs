using System;
using ArrayHelper;
using RectangleHelper;

namespace M01_Introduction
{
    internal class Program
    {
        private static void Main()
        {
            // Создание массива для Sort
            Console.WriteLine("Сортировка массива. Диапазон значений элементов массива от -100 до 100)");
            Random rnd = new();
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

            Sort.SortASC(array, true);
            Console.Write("\nМассив отсортированный по возрастанию: ");
            foreach (var item in array)
            {
                Console.Write(item + ", ");
            }

            Sort.SortASC(array, false);
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
            Console.WriteLine(Sum.Summ(array2));

            // прямоугольник
            Console.WriteLine("\nРассчет параметров прямоугольника");
            Console.Write("Длина прямоугольника: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ширина прямоугольника: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Rectangl rect = new(a, b);
            Console.WriteLine("Площадь прямоугольника: " + rect.Square());
            Console.WriteLine("Периметр прямоугольника: " + rect.Perimetr());
        }
    }
}