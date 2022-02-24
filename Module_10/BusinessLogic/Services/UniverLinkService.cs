using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    internal class UniverLinkService : IUniverLinkService
    {
        private readonly IUniverService<StudentDb> studentservice;
        private readonly IUniverService<HomeWorkDb> hwservice;
        private readonly IUniverService<LectureDb> lectureservice;
        private readonly IReportRepository reportRepository;

        public UniverLinkService(
            IUniverService<StudentDb> studentservice,
            IUniverService<HomeWorkDb> hwservice,
            IUniverService<LectureDb> lectionservice,
            IReportRepository reportRepository)
        {
            this.studentservice = studentservice;
            this.hwservice = hwservice;
            this.lectureservice = lectionservice;
            this.reportRepository = reportRepository;
        }

        public int NewAttendanceRecord(int lectureId, List<int> students, List<int> marks)
        {
            var readlecture = reportRepository.GetLinkedLecture(lectureId);
            readlecture.IsReaded = true;
            var visitedStudents = studentservice.GetSeveral(students);
            for (int i = 0; i < students.Count; i++)
            {
                readlecture.AttendanceLog.Add(new AttendanceLog
                {
                    Student = visitedStudents[i],
                    HomeWorkMark = marks[i],
                    //Lecture = currentLecture,
                    //LectureId = currentLecture.Id,
                    //StudentId = visitedStudents[i].Id,
                });
                //visitedStudents[i].VisitedLectures.Add(readlecture);
                lectureservice.Edit(readlecture);
            }

            //currentLecture.VisitedStudents.AddRange(visitedStudents);
            //lectureservice.Edit(currentLecture);
            //foreach (var item in visitedStudents)
            //{
            //    item.AttendanceLog.Add(new AttendanceLog
            //        {
            //        Lecture = readlecture
            //        });
            //    studentservice.Edit(item);
            //}

            var readLecturesId = lectureservice.GetAll().Where(x => x.IsReaded).Select(x => x.Id).ToList();
            int[] ar = new int[] { 1, 2, 3 };
            Notifications.checkTruancy(readLecturesId, reportRepository.GetSeveralLinkedStudents(ar.ToList()));
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