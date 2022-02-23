using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    internal class UniverLinkService : IUniverLinkService
    {
        private readonly IUniverService<StudentDb> studentservice;
        private readonly IUniverService<HomeWorkDb> hwservice;
        private readonly IUniverService<LectureDb> lectureservice;

        public UniverLinkService(IUniverService<StudentDb> studentservice, IUniverService<HomeWorkDb> hwservice, IUniverService<LectureDb> lectionservice)
        {
            this.studentservice = studentservice;
            this.hwservice = hwservice;
            this.lectureservice = lectionservice;
        }

        public int NewAttendanceRecord(int lecture, List<int> students, List<int> marks)
        {
            var currentLecture = lectureservice.Get(lecture);
            var currentStudents = studentservice.GetSeveral(students);
            for(int i = 0; i < students.Count; i++)
            {
                currentLecture.AttendanceLog.Add(new AttendanceLog
                {
                    Student = currentStudents[i],
                    HomeWorkMark = marks[i],
                    Lecture = currentLecture
                });
            }
            lectureservice.Edit(currentLecture);
            return 0;
        }

        public int NewHW(int lectureId, HomeWorkDb homeWork)
        {
            var lecture = lectureservice.Get(lectureId);
            homeWork.Lecture = lecture;
            homeWork.LectureId = lectureId;
            var newHWId = hwservice.New(homeWork);
            lecture.HomeWork = hwservice.Get(newHWId);
            lectureservice.Edit(lecture);
            return newHWId;
        }

        public void EditHW(HomeWorkDb homeWork)
        {
            var currentHomeWork = hwservice.Get(homeWork.Id);
            currentHomeWork.HWDescription = homeWork.HWDescription;
            hwservice.Edit(currentHomeWork);
        }
    }
}