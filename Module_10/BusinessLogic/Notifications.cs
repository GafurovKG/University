namespace BusinessLogic
{
    using DataAccess.Models;
    using System.Text;

    internal static class Notifications
    {
        public static void checkTruancy(List<int> readlecturesId, IEnumerable<StudentDb> students)
        {
            const int maxTruancy = 3;
            var massageToLector = new StringBuilder();
            foreach (var student in students)
            {
                var visitedLecturesId = student.VisitedLectures.Select(x => x.Id).ToList();
                var visitedFromReadLectures = readlecturesId.Where(x => visitedLecturesId.Contains(x)).ToList();
                if (visitedFromReadLectures.Count() < maxTruancy && readlecturesId.Count() > maxTruancy)
                {
                    Console.WriteLine($"{student.Name} пропустил более 3-х лекций." +
                        $" Уведомление будет отпраленно студенту на {student.Email}");
                    massageToLector.AppendLine($"{student.Name} пропустл более 3-х лекций!)");
                }
            }

            if (massageToLector.Length != null)
            {
                Console.WriteLine($"Для лектора курса: {massageToLector}");
            }
        }

        public static void CheckAverageMark()
        {

        }
    }
}