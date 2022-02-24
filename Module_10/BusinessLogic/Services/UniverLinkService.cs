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

        public int NewAttendanceRecord(int lectureId, List<AttendanceRecord> records)
        {
            var readlecture = reportRepository.GetLinkedLecture(lectureId);
            if (readlecture.IsReaded)
            {
                throw new Exception("$Лекция { readlecture.Id } уже была почтена");
                Console.WriteLine($"Лекция {readlecture.Id} уже была почтена");
            }

            readlecture.IsReaded = true;
            lectureservice.Edit(readlecture);
            var studentsID = records.Select(s => s.Student).ToList();
            var studentsMark = records.Select(s => s.Mark).ToList();
            var visitedStudents = studentservice.GetSeveral(studentsID);
            for (int i = 0; i < studentsID.Count; i++)
            {
                readlecture.AttendanceLog.Add(new AttendanceLog
                {
                    Student = visitedStudents[i],
                    HomeWorkMark = studentsMark[i],
                });

                lectureservice.Edit(readlecture);
            }

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