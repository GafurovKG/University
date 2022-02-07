namespace Domain
{
    using System.Collections.Generic;
    public interface IStudentsRepository
    {
        Student? Get(int id);
        IEnumerable<Student> GetAll();
        int New(Student student);
        void Edit(Student student);
        void Delete(int id);
    }
}