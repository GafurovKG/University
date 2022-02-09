using DataAccess;

namespace BusinessLogic
{
    internal class UniverService<TEntity> : IUniverService<TEntity>
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

        public void Edit(TEntity student)
        {
            univerRepository.Edit(student);
        }

        public TEntity? Get(int id)
        {
            return univerRepository.Get(id);
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            return univerRepository.GetAll().ToArray();
        }

        public int New(TEntity student)
        {
            return univerRepository.New(student);
        }
    }
}