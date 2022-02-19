namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IReportService
    {
        public IReadOnlyCollection<AttendanceLog> GetReport(string paramstring);
    }
}