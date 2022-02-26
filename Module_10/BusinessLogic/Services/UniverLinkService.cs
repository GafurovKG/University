using BusinessLogic.Exceptions;
using DataAccess;
using DataAccess.Models;
using Microsoft.Extensions.Logging;

namespace BusinessLogic
{
    internal class UniverLinkService : IUniverLinkService
    {
        private readonly IUniverService<StudentDb> studentservice;
        private readonly IUniverService<HomeWorkDb> hwservice;
        private readonly IUniverService<LectureDb> lectureservice;
        private readonly IReportRepository reportRepository;
        private readonly ILogger<UniverLinkService> logger;

        public UniverLinkService(
            IUniverService<StudentDb> studentservice,
            IUniverService<HomeWorkDb> hwservice,
            IUniverService<LectureDb> lectionservice,
            IReportRepository reportRepository,
            ILogger<UniverLinkService> logger)
        {
            this.studentservice = studentservice;
            this.hwservice = hwservice;
            this.lectureservice = lectionservice;
            this.reportRepository = reportRepository;
            this.logger = logger;
        }

        public int NewAttendanceRecord(int lectureId, IQueryable<AttendanceRecord> visitedStud)
        {
            var readlecture = reportRepository.GetLinkedLecture(lectureId);
            if (readlecture.IsReaded)
            {
                var message = $"Лекция { readlecture.Id } уже была прочтена, попытка перезаписать лекцию";
                throw new LectureWasReadExceptions(message);
            }

            if (visitedStud == null || visitedStud.Count() == 0)
            {
                var message = $"Лекцию {readlecture} не посетил ни один студент или данные не были переданы";
                throw new StudentsDidntAttendLecture(message);
            }

            readlecture.IsReaded = true;
            lectureservice.Edit(readlecture);
            var visitedStudentsID = visitedStud.Select(s => s.StudentId);
            var visitedStudentsHWMark = visitedStud.Select(s => s.Mark).ToList();
            var visitedStudents = reportRepository.GetSeveralLinkedStudents(visitedStudentsID).ToList();
            for (int i = 0; i < visitedStudentsID.Count(); i++)
            {
                readlecture.AttendanceLog.Add(new AttendanceLog
                {
                    Student = visitedStudents[i],
                    HomeWorkMark = visitedStudentsHWMark[i],
                });

                lectureservice.Edit(readlecture);
            }

            var allreadLectures = reportRepository.GetReadLecturesCount();
            var trucancyStudents = reportRepository.GetTruancyStudents();
            if (trucancyStudents != null)
            {
                Notifications.NoticeTruancyStudents(trucancyStudents, logger);
            }

            var lesserStudents = reportRepository.GetLesserStudents();
            if (lesserStudents != null)
            {
                Notifications.NoticeLesser(lesserStudents, logger);
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