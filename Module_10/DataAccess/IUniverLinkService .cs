namespace DataAccess
{
    using DataAccess.Models;

    public interface IUniverLinkService
    {
        int NewHW(int lectureId, HomeWorkDb homeWork);
        void EditHW(HomeWorkDb homeWork);
    }
}