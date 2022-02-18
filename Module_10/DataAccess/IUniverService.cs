namespace DataAccess
{
    using System.Collections.Generic;

    public interface IUniverService<TEntity> where TEntity : class
    {
        TEntity? Get(int id);
        IReadOnlyCollection<TEntity> GetAll();
        IReadOnlyCollection<TEntity> GetSome(int[] ids);
        int New(TEntity student);
        void Edit(TEntity student);
        void Delete(int id);
    }
}