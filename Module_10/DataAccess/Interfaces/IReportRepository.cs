namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IReportRepository
    {
        int New(AttendanceLog record);
        //void Edit(AttendanceLog record);
        IEnumerable<AttendanceLog> GetAll();
        IEnumerable<AttendanceLog> GetLectures(string[] lectures);
        IEnumerable<AttendanceLog> GetStudents(string[] students);

    }
}