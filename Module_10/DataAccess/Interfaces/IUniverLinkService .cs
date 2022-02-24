namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Models;

    public interface IUniverLinkService
    {
        int NewHW(int lectureId, HomeWorkDb homeWork);
        void EditHW(HomeWorkDb homeWork);
        int NewAttendanceRecord(int lecture, List<AttendanceRecord> records);
    }
}