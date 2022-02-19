﻿namespace DataAccess
{
    using System.Collections.Generic;
    public interface IUniverRepository<TEntity>
        where TEntity : class
    {
        TEntity? Get(int id);
        IReadOnlyCollection<TEntity> GetAll();
        IEnumerable<TEntity> GetSeveral(int[] ids);
        int New(TEntity student);
        void Edit(TEntity student);
        void Delete(int id);
    }
}