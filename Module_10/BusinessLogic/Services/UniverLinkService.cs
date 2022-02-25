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

        public int NewAttendanceRecord(int lectureId, List<AttendanceRecord> visitedStud)
        {
            var readlecture = reportRepository.GetLinkedLecture(lectureId);
            if (readlecture.IsReaded)
            {
                Console.WriteLine($"Лекция {readlecture.Id} уже была почтена");

                // throw new Exception("$Лекция { readlecture.Id } уже была прочтена");
                return 0;
            }

            if (visitedStud == null || visitedStud.Count == 0)
            {
                Console.WriteLine($"Лекцию {readlecture} не посетил ни один студент или данные не были переданы");
                return 0;
            }

            readlecture.IsReaded = true;
            lectureservice.Edit(readlecture);
            var studentsID = visitedStud.Select(s => s.Student).ToList();
            var studentsMark = visitedStud.Select(s => s.Mark).ToList();
            var visitedStudents = studentservice.GetSeveral(studentsID);

            if (visitedStudents == null || visitedStud.Count == 0)
            {
                Console.WriteLine($"В БД не найдены студенты с указанными Id");
                return 0;
            }

            for (int i = 0; i < studentsID.Count; i++)
            {
                readlecture.AttendanceLog.Add(new AttendanceLog
                {
                    Student = visitedStudents[i],
                    HomeWorkMark = studentsMark[i],
                });

                lectureservice.Edit(readlecture);
            }

            var trucancyStudents = reportRepository.GetTruancyStudents();
            if (trucancyStudents != null)
            {
            Notifications.NoticeTruancyStudents(trucancyStudents);
            }

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