namespace Domain
{
    using System.Collections.Generic;
    using Domain.Models;

    public interface IStudentsService<TEntity> where TEntity : class
    {
        TEntity? Get(int id);
        IReadOnlyCollection<TEntity> GetAll();
        int New(TEntity student);
        void Edit(TEntity student);
        void Delete(int id);
    }
}