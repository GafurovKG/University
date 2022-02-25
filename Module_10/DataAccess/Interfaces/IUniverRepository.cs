namespace DataAccess
{
    using System.Collections.Generic;

    public interface IUniverRepository<TEntity>
        where TEntity : class
    {
        TEntity? Get(int id);
        List<TEntity> GetSeveral(List<int> ids);
        IReadOnlyCollection<TEntity> GetAll();
        List<int> GetAllIds();
        int New(TEntity student);
        void Edit(TEntity student);
        void Delete(int id);
    }
}