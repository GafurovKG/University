using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    internal class UniverLinkService : IUniverLinkService
    {
        private readonly IUniverService<HomeWorkDb> hwservice;
        private readonly IUniverService<LectureDb> lectionservice;

        public UniverLinkService(IUniverService<HomeWorkDb> hwservice, IUniverService<LectureDb> lectionservice)
        {
            this.hwservice = hwservice;
            this.lectionservice = lectionservice;
        }

        public int NewHW(int lectureId, HomeWorkDb homeWork)
        {
            var lecture = lectionservice.Get(lectureId);
            homeWork.Lecture = lecture;
            homeWork.LectureId = lectureId;
            var newHWId = hwservice.New(homeWork);
            lecture.HomeWork = hwservice.Get(newHWId);
            lectionservice.Edit(lecture);
            return newHWId;
        }

        public void EditHW(HomeWorkDb homeWork)
        {
            var currentHomeWork = hwservice.Get(homeWork.Id);
            currentHomeWork.HWDescription = homeWork.HWDescription;
            hwservice.Edit(currentHomeWork);
        }

        //public void Delete(int id)
        //{
        //    univerRepository.Delete(id);
        //}

        //public void Edit(TEntity entity)
        //{
        //    univerRepository.Edit(entity);
        //}

        //public TEntity? Get(int id)
        //{
        //    return univerRepository.Get(id);
        //}

        //public IReadOnlyCollection<TEntity> GetAll()
        //{
        //    return univerRepository.GetAll().ToArray();
        //}

        //public int New(TEntity entity)
        //{
        //    return univerRepository.New(entity);
        //}
    }
}