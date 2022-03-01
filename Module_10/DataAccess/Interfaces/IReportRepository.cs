namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IReportRepository
    {
        IEnumerable<StudentDb> GetAllLinkedStudents();
        LectureDb GetLinkedLecture(int id);
        StudentDb GetLinkedStudent(int id);
        IEnumerable<LectureDb> GetSeveralLinkedLectures(List<int> ids);
        IEnumerable<StudentDb> GetSeveralLinkedStudents(IEnumerable<int> ids);
        IEnumerable<AttendanceLog> GetAll();
        IEnumerable<AttendanceLog> GetStudents(int[] studentsId);
        IEnumerable<AttendanceLog> GetStudents(string[] students);
        IEnumerable<AttendanceLog> GetLectures(int[] lectures);
        IEnumerable<AttendanceLog> GetLectures(string[] lectures);
        IEnumerable<StudentDb>? GetTruancyStudents();
        int GetReadLecturesCount();
        IEnumerable<AverageMarkLog>? GetLesserStudents();
    }
}