using System.Linq.Expressions;
using DataAccess;

namespace BusinessLogic
{
    public class UniverService<TEntity> : IUniverService<TEntity>
        where TEntity : class
    {
        private readonly IUniverRepository<TEntity> univerRepository;

        public UniverService(IUniverRepository<TEntity> univerRepository)
        {
            this.univerRepository = univerRepository;
        }

        public void Delete(int id)
        {
            univerRepository.Delete(id);
        }

        public void Edit(TEntity entity)
        {
            univerRepository.Edit(entity);
        }

        public TEntity Get(int id)
        {
            return univerRepository.Get(id);
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            return univerRepository.GetAll().ToArray();
        }

        public List<int> GetAllIds()
        {
            return univerRepository.GetAllIds();
        }

        public int New(TEntity entity)
        {
            return univerRepository.New(entity);
        }

        List<TEntity> IUniverService<TEntity>.GetSeveral(List<int> ids)
        {
            return univerRepository.GetSeveral(ids);
        }
    }
}