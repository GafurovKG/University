using Domain;
using Domain.Models;

namespace BusinessLogic
{
    internal class StudentsService<TEntity> : IStudentsService<TEntity> where TEntity : class
    {
        private readonly IStudentsRepository<TEntity> studentsRepository;

        public StudentsService(IStudentsRepository<TEntity> studentsRepository)
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