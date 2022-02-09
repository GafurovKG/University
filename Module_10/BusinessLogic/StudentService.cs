using DataAccess;

namespace BusinessLogic
{
    internal class StudentsService<TEntity> : IUniverService<TEntity>
        where TEntity : class
    {
        private readonly IUniverRepository<TEntity> studentsRepository;

        public StudentsService(IUniverRepository<TEntity> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public void Delete(int id)
        {
            studentsRepository.Delete(id);
        }

        public void Edit(TEntity student)
        {
            studentsRepository.Edit(student);
        }

        public TEntity? Get(int id)
        {
            return studentsRepository.Get(id);
        }

        public IReadOnlyCollection<TEntity> GetAll()
        {
            return studentsRepository.GetAll().ToArray();
        }

        public int New(TEntity student)
        {
            return studentsRepository.New(student);
        }
    }
}