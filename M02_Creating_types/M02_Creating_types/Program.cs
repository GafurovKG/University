using System;
using System.Collections.Generic;

namespace M02_Creating_types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] subjects = { "Maths", "Philosophy", "History", "PE", "English", "Sport" };
            
            var student1c1 = new Student("pete.pupkin@epam.com");
            var student2c1 = new Student("vasa.vasechkin@epam.com");
            var student3c1 = new Student("kola.kolishev@epam.com");

            var student1c2 = new Student("pete", "pupkin");
            var student2c2 = new Student("vasa", "vasechkin");
            var student3c2 = new Student("kola", "kolishev");

            var students = new List<Student>() { student1c1, student1c2, student2c1, student2c2, student3c1, student3c2 };

            Dictionary<Student, HashSet<string>> studentSubjectDict = new();

            //запоняем studentSubjectDict через циклы. При встече дубликатов по key хэш, они отлетают, Value остается от первого записаннго student 
            Random rand = new Random();
            foreach (var stud in students)
            {
                HashSet<string> subj = new HashSet<string>();
                do
                {
                    subj.Add(subjects[rand.Next(5)]); //предметы тожене не должны повтояться
                } while (subj.Count <= 2);
                studentSubjectDict.TryAdd(stud, subj);
            }

            ////Если инициализировать Value при инициаизации элемента Dictionary, то Value перезапишется в имеющийся элемент с таким же хэш key
            //studentSubjectDict[student1c1] = new HashSet<string> { "Maths", "Philosophy", "History" };
            //studentSubjectDict[student1c2] = new HashSet<string> { "History", "PE", "English" };

            //проверка итогового studentSubjectDict
            foreach (var dict in studentSubjectDict)
            {
                Console.WriteLine(dict.Key.ShowInfo());
                foreach (var subj in dict.Value)
                {
                    Console.Write(subj + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
