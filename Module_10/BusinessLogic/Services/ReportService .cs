using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    internal class RepotrService : IReportService
    {
        private readonly IReportRepository reportRepository;
        private readonly IUniverRepository<StudentDb> studentRepository;
        private readonly IUniverRepository<LectureDb> lectureRepository;

        public RepotrService(
            IReportRepository reportRepository,
            IUniverRepository<StudentDb> studentRepository,
            IUniverRepository<LectureDb> lectureRepository)
        {
            this.reportRepository = reportRepository;
            this.lectureRepository = lectureRepository;
            this.studentRepository = studentRepository;
        }

        public IEnumerable<AttendanceLog> GetReport(string[] students, string[] lectures)
        {
            var response = reportRepository.GetStudents(students).ToList();
            response.AddRange(reportRepository.GetLectures(lectures));
            return response;
        }

        public IEnumerable<AttendanceLog> GetReport()
        {
            var response = reportRepository.GetAll().ToList();
            return response;
        }
    }
}