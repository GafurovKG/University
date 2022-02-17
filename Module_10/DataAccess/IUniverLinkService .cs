namespace DataAccess
{
    using DataAccess.Models;

    public interface IUniverLinkService
    {
        int NewHW(int lectureId, HomeWorkDb homeWork);

        void EditHW(HomeWorkDb homeWork);

        //IUniverLinkService? Get(int id);
        //IReadOnlyCollection<IUniverLinkService> GetAll();
        //int New(IUniverLinkService entity);
        //void Edit(IUniverLinkService entity);
        //void Delete(int id);
    }
}