namespace DataAccess
{
    using System.Collections.Generic;
    using DataAccess.Exceptions;
    using Microsoft.EntityFrameworkCore;

    internal class UniverRepository<TEntity> : IUniverRepository<TEntity>
        where TEntity : class, IIdPrpperty
    {
        private readonly UniverDbContext context;

        public UniverRepository(UniverDbContext UniverContext)
        {
            context = UniverContext;
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            var response = context.Set<TEntity>().ToList();
            if (response == null || response.Count == 0)
            {
                throw new ObjectNotFoundInDb("Запись или записи не найдены в БД");
            }

            return response;
        }

        public List<int> GetAllIds()
        {
            var response = context.Set<TEntity>().Select(x => x.Id).ToList();
            if (response == null || response.Count == 0)
            {
                throw new ObjectNotFoundInDb("Запись или записи не найдены в БД");
            }

            return response;
        }

        public TEntity Get(int id)
        {
            var response = context.Set<TEntity>().Find(id);
            if (response == null)
            {
                throw new ObjectNotFoundInDb($"Запись c Id {id} не найдена в БД");
            }

            return response;
        }

        public int New(TEntity entity)
        {
            var result = context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return result.Entity.Id;
        }

        public int Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var response = context.Set<TEntity>().Find(id);
            if (response == null)
            {
                throw new ObjectNotFoundInDb($"Запись c Id {id} не найдена в БД");
            }

            context.Entry(response).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<TEntity> GetSeveral(List<int> ids)
        {
            var response = context.Set<TEntity>()
                .Where(x => ids.Contains(x.Id)).ToList();
            if (response == null)
                {
                    throw new ObjectNotFoundInDb($"Записи c Id {ids} не найдены в БД");
                }

            return response;
        }
    }
}