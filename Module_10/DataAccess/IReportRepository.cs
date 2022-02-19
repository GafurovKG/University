namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IReportRepository
    {
        void Edit(AttendanceLog record);
        IEnumerable<AttendanceLog> GetAll();
        IEnumerable<AttendanceLog> GetLecture(int lectureId);
        IEnumerable<AttendanceLog> GetSeveral(int[] ids);
        IEnumerable<AttendanceLog> GetStudent(int studentId);
        int New(AttendanceLog record);
    }
}