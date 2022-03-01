using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    internal class RepotrService : IReportService
    {
        private readonly IReportRepository reportRepository;

        public RepotrService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
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