namespace DataAccess
{
    using DataAccess.Models;

    public interface IUniverLinkService
    {
        int CreateHW(int lectureId, HomeWorkDb homeWork);
        void EditHW(HomeWorkDb homeWork);
        LectureDb CreateAttendanceRecord(int lecture, IEnumerable<AttendanceRecord> records);
    }
}