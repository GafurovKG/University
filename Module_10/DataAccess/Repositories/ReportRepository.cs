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

            return mapper.Map<IEnumerable<AttendanceLog>>(response);
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

            return mapper.Map<IEnumerable<AttendanceLog>>(response);
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

            return mapper.Map<IEnumerable<AttendanceLog>>(response);
        }
    }
}