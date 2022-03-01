namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IReportService
    {
        public IEnumerable<AttendanceLog> GetReport(string[] students, string[] lectures);
        public IEnumerable<AttendanceLog> GetReport();
    }
}