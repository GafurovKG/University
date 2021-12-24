using System;
using System.IO;


namespace M03_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1. Average length of words
            Console.WriteLine("Задача 1. Расчет срдней длины слов");
            Console.WriteLine("Введите строку для расчета средней длины слова: ");

            var str = Console.ReadLine();

            double average = WordsAverageLength.DoIt(str);

            Console.WriteLine("Средняя длина слова - {0:0.0} символов", average);

            ////Task 2. Doubles
            Console.WriteLine("\nЗадаа 2. Дублировние символов");
            Console.WriteLine("Введите первую строку:");
            var str1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            var str2 = Console.ReadLine();
            Console.WriteLine(Doubles.DoIt(str1, str2));

            //Task 3. Sum of overlongs
            // Полагем, что вводятся только цифры. Если делать все проверки. я бы сделал нестатичекий класс с конструторами и сеттерами для воодимых строк
            Console.WriteLine("\nЗадача 3. Сумма больших положительнх чисел");
            Console.WriteLine("Введи число 1");
            string number1 = Console.ReadLine();
            Console.WriteLine("Введи число 2");
            string number2 = Console.ReadLine();
            Console.WriteLine("Сумма чисел: " + LongSum.DoIt(number1, number2));

            ////Task 4. Reverse words
            Console.WriteLine("\nЗадача 4. Реверс строки. Введи строку:");
            var strFoReverse = Console.ReadLine();
            Console.WriteLine(ReverseWords.DoIt(strFoReverse));

            //Task 5 Phone nombers
            Console.WriteLine("\nЗадача 5. Поиск номеров в строке в text.txt. Нажмите любую клавишу");
            Console.ReadKey();
            StreamReader sr = new (@"..\..\..\text.txt");
            string inputText = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new (@"..\..\..\Numbers.txt");
            foreach (var item in PhoneNumbers.DoIt(inputText))
            {
            sw.WriteLine(item);
            }
            sw.Close();
            Console.WriteLine("Номера телефонов записаны в Numbers.txt");
        }
    }
}
