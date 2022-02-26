namespace DataAccess
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess.Models;

    public interface IReportRepository
    {
        IEnumerable<StudentDb> GetAllLinkedStudents();
        LectureDb GetLinkedLecture(int id);
        StudentDb GetLinkedStudent(int id);
        List<LectureDb> GetSeveralLinkedLectures(List<int> ids);
        IQueryable<StudentDb> GetSeveralLinkedStudents(IQueryable<int> ids);
        IEnumerable<AttendanceLog> GetAll();
        IEnumerable<AttendanceLog> GetStudents(int[] studentsId);
        IEnumerable<AttendanceLog> GetStudents(string[] students);
        IEnumerable<AttendanceLog> GetLectures(int[] lectures);
        IEnumerable<AttendanceLog> GetLectures(string[] lectures);
        IQueryable<StudentDb>? GetTruancyStudents();
        int GetReadLecturesCount();
        IEnumerable<AverageMarkLog>? GetLesserStudents();
    }
}