namespace BusinessLogic
{
    using System.Text;
    using DataAccess.Models;
    using Microsoft.Extensions.Logging;

    internal static class Notifications
    {
        public static void NoticeTruancyStudents(IEnumerable<StudentDb> truancyStudents, ILogger logger)
        {
            var massageToLector = new StringBuilder();
            foreach (var truancyStudent in truancyStudents)
            {
                var massage = $"{truancyStudent.Name} пропустил более 3-х лекций!";
                massageToLector.AppendLine(massage);
                logger.LogInformation($"{massage} Уведомление будет отпраленно студенту на {truancyStudent.Email}");

                // метод отправки email
            }

            if (massageToLector.Length != 0)
            {
                logger.LogInformation($"Сообщение лектору курса о студнтамх:\n {massageToLector}");

                // метод отправки email
            }
        }

        public static void NoticeLesser(IEnumerable<AverageMarkLog> lessersStudents, ILogger logger)
        {
            foreach (var student in lessersStudents)
            {
                var message = $"{student.Name} имеет седнюю оцнку ниже 4!" +
                    $" Будет отправленно СМС по телефону {student.tel}";
                logger.LogInformation(message);

                // метод отправки СМС
            }
        }
    }
}