namespace Domain
{
    using System.Collections.Generic;
    public interface IStudentsService
    {
        Student? Get(int id);
        IReadOnlyCollection<Student> GetAll();
        int New(Student student);
        int Edit(Student student);
        void Delete(int id);
    }
}