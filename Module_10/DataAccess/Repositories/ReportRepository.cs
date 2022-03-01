namespace DataAccess
{
    using System.Linq;
    using DataAccess.Exceptions;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    internal class ReportRepository : IReportRepository
    {
        private readonly UniverDbContext context;

        public ReportRepository(UniverDbContext UniverContext)
        {
            context = UniverContext;
        }

        public IEnumerable<AttendanceLog> GetAll()
        {
            var response = context.Students
                            .Include(x => x.AttendanceLog)
                            .ThenInclude(x => x.Lecture)
                            .SelectMany(
                                x => x.AttendanceLog,
                                (student, AttendanceRecord) => new AttendanceLog(AttendanceRecord) { Student = student })
                            .ToList();
            if (response == null || response.Count == 0)
            {
                throw new ObjectNotFoundInDb($"В журнале посещаемости нет записей");
            }

            return response;
        }

        public IEnumerable<AttendanceLog> GetStudents(string[] students)
        {
            var list = students.ToList();

            var response = context.Students
                .Where(x => list.Contains(x.Name))
                .Include(x => x.AttendanceLog)
                .ThenInclude(x => x.Lecture)
                .SelectMany(
                    x => x.AttendanceLog,
                    (student, AttendanceRecord) => new AttendanceLog(AttendanceRecord) { Student = student })
                .ToList();

            return response;
        }

        public IEnumerable<AttendanceLog> GetStudents(int[] studentsId)
        {
            var list = studentsId.ToList();

            var response = context.Students
                .Where(x => list.Contains(x.Id))
                .Include(x => x.AttendanceLog)
                .ThenInclude(x => x.Lecture)
                .SelectMany(
                    x => x.AttendanceLog,
                    (student, AttendanceRecord) => new AttendanceLog(AttendanceRecord) { Student = student })
                .ToList();
            if (response == null || response.Count == 0)
            {
                throw new ObjectNotFoundInDb($"Студенты {studentsId} не найдены в БД");
            }

            return response;
        }

        public IEnumerable<AttendanceLog> GetLectures(string[] lectures)
        {
            var list = lectures.ToList();

            var response = context.Lectures
                .Where(x => list.Contains(x.LectureTheme))
                .Include(x => x.AttendanceLog)
                .ThenInclude(x => x.Student)
                .SelectMany(
                    x => x.AttendanceLog,
                    (lecture, AttendanceRecord) => new AttendanceLog(AttendanceRecord) { Lecture = lecture })
                .ToList();

            return response;
        }

        public IEnumerable<AttendanceLog> GetLectures(int[] lecturesId)
        {
            var list = lecturesId.ToList();

            var response = context.Lectures
                .Where(x => list.Contains(x.Id))
                .Include(x => x.AttendanceLog)
                .ThenInclude(x => x.Student)
                .SelectMany(
                    x => x.AttendanceLog,
                    (lecture, AttendanceRecord) => new AttendanceLog(AttendanceRecord) { Lecture = lecture })
                .ToList();

            if (response == null || response.Count == 0)
            {
                throw new ObjectNotFoundInDb($"Лекции {lecturesId} не найдены в БД");
            }

            return response;
        }

        public IEnumerable<StudentDb> GetAllLinkedStudents()
        {
            var response = context.Students
            .Include(l => l.VisitedLectures)
            .Include(a => a.AttendanceLog);
            if (response == null || response.Count() == 0)
            {
                throw new ObjectNotFoundInDb($"Студенты не найдены в БД");
            }

            return response;
        }

        public StudentDb GetLinkedStudent(int id)
        {
            var response = context.Students
                .Where(s => s.Id == id)
                .Include(l => l.VisitedLectures)
                .Include(a => a.AttendanceLog)
                .FirstOrDefault();
            if (response == null)
            {
                throw new ObjectNotFoundInDb($"Студент {id} не найден в БД");
            }

            return response;
        }

        public LectureDb GetLinkedLecture(int id)
        {
            var response = context.Lectures
                .Where(s => s.Id == id)
                .Include(l => l.VisitedStudents)
                .Include(a => a.AttendanceLog).FirstOrDefault();
            if (response == null)
            {
                throw new ObjectNotFoundInDb($"Лекция {id} не найдена в БД");
            }

            return response;
        }

        public IEnumerable<StudentDb> GetSeveralLinkedStudents(IEnumerable<int> ids)
        {
            var response = context.Students
                .Where(x => ids.Contains(x.Id))
                .Include(l => l.VisitedLectures)
                .Include(a => a.AttendanceLog);
            if (response == null || response.Count() == 0)
            {
                throw new ObjectNotFoundInDb($"Студенты {ids} не найдены в БД");
            }

            return response;
        }

        public IEnumerable<LectureDb> GetSeveralLinkedLectures(List<int> ids)
        {
            var response = context.Lectures
                .Where(x => ids.Contains(x.Id))
                .Include(l => l.VisitedStudents)
                .Include(a => a.AttendanceLog);
            if (response == null || response.Count() == 0)
            {
                throw new ObjectNotFoundInDb($"Лекции {ids} не найдены в БД");
            }

            return response.ToList();
        }

        public IEnumerable<StudentDb>? GetTruancyStudents()
        {
            var readLectures = context.Lectures.Where(l => l.IsReaded).Count();
            var response = context.Set<StudentDb>().Where(x => readLectures - x.VisitedLectures.Count > 3);
            return response;
        }

        public int GetReadLecturesCount()
        {
            return context.Lectures.Where(l => l.IsReaded).Select(l => l.Id).Count();
        }

        public IEnumerable<AverageMarkLog>? GetLesserStudents()
        {
            var response = context.Set<AttendanceLog>()
                .Include(x => x.Student)
                .GroupBy(x => x.StudentId)
                .Select(x => new { Average = x.Average(x => x.HomeWorkMark), x.First().Student }).ToList()
                .Where(am => am.Average > 4);
            return response.Select(x => new AverageMarkLog(x.Student.Id, x.Student.Name, x.Student.Tel, x.Average));
        }
    }
}