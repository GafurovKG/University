namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IReportRepository
    {
        IEnumerable<AttendanceLog> GetAll();
        IEnumerable<AttendanceLog> GetLectures(string[] lectures);
        IEnumerable<AttendanceLog> GetStudents(string[] students);

    }
}