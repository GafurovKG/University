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
        public int New(AttendanceLog record)
        {
            var dbEntity = mapper.Map<AttendanceLog>(record);
            var result = context.Set<AttendanceLog>().Add(dbEntity);
            context.SaveChanges();
            return result.Entity.Id;
        }

        public IEnumerable<AttendanceLog> GetAll()
        {
            var response = context.Students
                            .Include(x => x.AttendanceLog)
                            .ThenInclude(x => x.Lecture)
                            .SelectMany(x => x.AttendanceLog.DefaultIfEmpty(),
                            (name, lecture) => new AttendanceLog { Student = name, Lecture = lecture.Lecture })
                            .ToList();

            return mapper.Map<IEnumerable<AttendanceLog>>(response);
        }

        public IEnumerable<AttendanceLog> GetStudents(string[] students)
        {
            var list = students.ToList();

            var response = context.Students
                .Where(x => list.Contains(x.Name))
                .Include(x => x.AttendanceLog)
                .ThenInclude(x => x.Lecture)
                .SelectMany(x => x.AttendanceLog.DefaultIfEmpty(),
                (name, lecture) => new AttendanceLog { Student = name, Lecture = lecture.Lecture })
                .ToList();

            return mapper.Map<IEnumerable<AttendanceLog>>(response);
        }

        public IEnumerable<AttendanceLog> GetLectures(string[] lectures)
        {
            var list = lectures.ToList();

            var response = context.Lectures
                .Where(x => list.Contains(x.LectureTheme))
                .Include(x => x.AttendanceLog)
                .ThenInclude(x => x.Student)
                .SelectMany(x => x.AttendanceLog.DefaultIfEmpty(),
                (theme, student) => new AttendanceLog { Lecture = theme, Student = student.Student})
                .ToList();

            return mapper.Map<IEnumerable<AttendanceLog>>(response);
        }
    }
}