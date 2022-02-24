namespace BusinessLogic
{
    using DataAccess.Models;
    using System.Text;

    internal static class Notifications
    {
        public static void NoticeTruancyStudents(IQueryable<StudentDb> truancyStudents)
        {
            var massageToLector = new StringBuilder();
            foreach (var truancyStudent in truancyStudents)
            {
                Console.WriteLine($"{truancyStudent.Name} пропустил более 3-х лекций." +
                $" Уведомление будет отпраленно студенту на {truancyStudent.Email}");
                massageToLector.AppendLine($"{truancyStudent.Name} пропустл более 3-х лекций!)");
            }

            if (massageToLector.Length != 0)
            {
                Console.WriteLine($"Для лектора курса:\n {massageToLector}");
            }
        }

        public static void CheckAverageMark()
        {

        }
    }
}