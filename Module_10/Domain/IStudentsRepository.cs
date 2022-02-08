namespace Domain
{
    using System.Collections.Generic;
    public interface IStudentsRepository<TEntity>
        where TEntity : class
    {
        TEntity? Get(int id);
        IEnumerable<TEntity> GetAll();
        int New(TEntity student);
        void Edit(TEntity student);
        void Delete(int id);
    }
}