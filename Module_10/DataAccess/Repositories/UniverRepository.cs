namespace DataAccess
{
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    internal class UniverRepository<TEntity> : IUniverRepository<TEntity>
        where TEntity : class, IIdPrpperty
    {
        private readonly UniverDbContext context;
        private readonly IMapper mapper;

        public UniverRepository(UniverDbContext UniverContext, IMapper mapper)
        {
            context = UniverContext;
            this.mapper = mapper;
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            var responre = context.Set<TEntity>().ToList();
            return responre;
        }

        public List<int> GetAllIds()
        {
            return context.Set<TEntity>().Select(x => x.Id).ToList();
        }

        public TEntity? Get(int id)
        {
            var db = context.Set<TEntity>().Find(id);
            return mapper.Map<TEntity?>(db);
        }

        public int New(TEntity entity)
        {
            var dbEntity = mapper.Map<TEntity>(entity);
            var result = context.Set<TEntity>().Add(dbEntity);
            context.SaveChanges();
            return result.Entity.Id;
        }

        public void Edit(TEntity entity)
        {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = context.Set<TEntity>().Find(id);
            context.Entry(entityToDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<TEntity>? GetSeveral(List<int> ids)
        {
            var response = context.Set<TEntity>()
                .Where(x => ids.Contains(x.Id)).ToList();
            return response;
        }
    }
}