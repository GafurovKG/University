namespace DataAccess
{
    using System.Linq;
    using AutoMapper;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    internal class ReportRepository : IReportRepository

    {
        private readonly UniverDbContext context;
        private readonly IMapper mapper;

        public ReportRepository(UniverDbContext UniverContext, IMapper mapper)
        {
            context = UniverContext;
            this.mapper = mapper;
        }

        public IEnumerable<AttendanceLog> GetAll()
        {
            var response = context.Students
                            .Include(x => x.AttendanceLog)
                            .ThenInclude(x => x.Lecture)
                            .SelectMany(x => x.AttendanceLog,
                             (student, AttendanceRecord) => new AttendanceLog(AttendanceRecord) { Student = student })
                            .ToList();

            return response;
        }

        public IEnumerable<AttendanceLog> GetStudents(string[] students)
        {
            var list = students.ToList();

            var response = context.Students
                .Where(x => list.Contains(x.Name))
                .Include(x => x.AttendanceLog)
                .ThenInclude(x => x.Lecture)
                .SelectMany(x => x.AttendanceLog,
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
                .SelectMany(x => x.AttendanceLog,
                (student, AttendanceRecord) => new AttendanceLog(AttendanceRecord) { Student = student })
                .ToList();

            return response;
        }

        public IEnumerable<AttendanceLog> GetLectures(string[] lectures)
        {
            var list = lectures.ToList();

            var response = context.Lectures
                .Where(x => list.Contains(x.LectureTheme))
                .Include(x => x.AttendanceLog)
                .ThenInclude(x => x.Student)
                .SelectMany(x => x.AttendanceLog,
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
                .SelectMany(x => x.AttendanceLog,
                (lecture, AttendanceRecord) => new AttendanceLog(AttendanceRecord) { Lecture = lecture })
                .ToList();

            return response;
        }

        public IEnumerable<StudentDb> GetAllLinkedStudents()
        {
            var response = context.Students
            .Include(l => l.VisitedLectures)
            .Include(a => a.AttendanceLog);

            return response;
        }

        public StudentDb GetLinkedStudent(int id)
        {
            var response = context.Students
                .Where(s => s.Id == id)
                .Include(l => l.VisitedLectures)
                .Include(a => a.AttendanceLog)
                .FirstOrDefault();
            return response;
        }

        public LectureDb GetLinkedLecture(int id)
        {
            var response = context.Lectures
                .Where(s => s.Id == id)
                .Include(l => l.VisitedStudents)
                .Include(a => a.AttendanceLog).FirstOrDefault();
            return response;
        }

        public List<StudentDb> GetSeveralLinkedStudents(List<int> ids)
        {
            var response = context.Students
                .Where(x => ids.Contains(x.Id))
                .Include(l => l.VisitedLectures)
                .Include(a => a.AttendanceLog);
            return response.ToList();
        }
        public List<LectureDb> GetSeveralLinkedLectures(List<int> ids)
        {
            var response = context.Lectures
                .Where(x => ids.Contains(x.Id))
                .Include(l => l.VisitedStudents)
                .Include(a => a.AttendanceLog);
            return response.ToList();
        }

        public IQueryable<StudentDb>? GetTruancyStudents()
        {
            var readLectures = context.Lectures.Where(l => l.IsReaded).Count();
            var response = context.Set<StudentDb>().Where(x => readLectures - x.VisitedLectures.Count > 3)
                /*.Select(x => new StudentDb { Name = x.Name, Email = x.Email }) - в этой строчке нет смысла?*/;
            return response;
        }

        public IQueryable<StudentDb>? CheckAverageMark()
        {
            return null;
        }
    }
}