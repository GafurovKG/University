namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IReportRepository
    {
        LectureDb GetLinkedLecture(int id);
        StudentDb GetLinkedStudent(int id);
        List<LectureDb> GetSeveralLinkedLectures(List<int> ids);
        List<StudentDb> GetSeveralLinkedStudents(List<int> ids);
        IEnumerable<AttendanceLog> GetAll();
        IEnumerable<AttendanceLog> GetStudents(int[] studentsId);
        IEnumerable<AttendanceLog> GetStudents(string[] students);
        IEnumerable<AttendanceLog> GetLectures(int[] lectures);
        IEnumerable<AttendanceLog> GetLectures(string[] lectures);

    }
}