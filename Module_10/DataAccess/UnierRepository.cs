namespace DataAccess
{
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

        public IEnumerable<TEntity> GetAll()
        {
            var db = context.Set<TEntity>().ToList();
            return mapper.Map<IReadOnlyCollection<TEntity>>(db);
        }

        public IEnumerable<TEntity> GetSome(int[] ids)
        {
            var db = context.Set<TEntity>().Find(ids);
            return mapper.Map<IReadOnlyCollection<TEntity>>(db);
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
    }
}