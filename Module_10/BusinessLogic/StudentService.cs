using Domain;

namespace BusinessLogic
{
    internal class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public void Delete(int id)
        {
            studentsRepository.Delete(id);
        }

        public int Edit(Student student)
        {
            studentsRepository.Edit(student);
            return student.Id;
        }

        public Student? Get(int id)
        {
            return studentsRepository.Get(id);
        }

        public IReadOnlyCollection<Student> GetAll()
        {
            return studentsRepository.GetAll().ToArray();
        }

        public int New(Student student)
        {
            return studentsRepository.New(student);
        }
    }
}