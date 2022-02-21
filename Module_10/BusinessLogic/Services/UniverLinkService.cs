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