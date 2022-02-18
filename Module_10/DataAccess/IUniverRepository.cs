namespace DataAccess
{
    using System.Collections.Generic;
    public interface IUniverRepository<TEntity>
        where TEntity : class
    {
        TEntity? Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetSome(int[] ids);
        int New(TEntity student);
        void Edit(TEntity student);
        void Delete(int id);
    }
}