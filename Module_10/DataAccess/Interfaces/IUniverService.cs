namespace DataAccess
{
    using System.Collections.Generic;

    public interface IUniverService<TEntity> where TEntity : class
    {
        TEntity? Get(int id);
        List<TEntity>? GetSeveral(List<int> id);
        IReadOnlyCollection<TEntity> GetAll();
        int New(TEntity student);
        void Edit(TEntity student);
        void Delete(int id);
    }
}