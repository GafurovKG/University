namespace DataAccess
{
    using System.Collections.Generic;

    public interface IUniverService<TEntity>
        where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> GetSeveral(List<int> id);
        IReadOnlyCollection<TEntity> GetAll();
        List<int> GetAllIds();
        int New(TEntity student);
        int Edit(TEntity student);
        void Delete(int id);
    }
}