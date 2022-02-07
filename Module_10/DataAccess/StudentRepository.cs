namespace DataAccess
{
    using AutoMapper;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    internal class StudentsRepository : IStudentsRepository
    {
        private readonly StudentDbContext context;
        private readonly IMapper mapper;

        public StudentsRepository(StudentDbContext studentContext, IMapper mapper)
        {
            context = studentContext;
            this.mapper = mapper;
        }

        public IEnumerable<Student> GetAll()
        {
            var studentDb = context.Students.ToList();
            return mapper.Map<IReadOnlyCollection<Student>>(studentDb);
        }

        public Student? Get(int id)
        {
            var studentDb = context.Students.FirstOrDefault(x => x.Id == id);
            return mapper.Map<Student?>(studentDb);
        }

        public int New(Student student)
        {
            var studentDb = mapper.Map<StudentDb>(student);
            var result = context.Students.Add(studentDb);
            context.SaveChanges();
            return result.Entity.Id;
        }

        public void Edit(Student student)
        {
            if (context.Students.Find(student.Id) is StudentDb studentInDb)
            {
                studentInDb.Name = student.Name;
                studentInDb.Email = student.Email;
                context.Entry(studentInDb).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var studentToDelete = context.Students.Find(id);
            context.Entry(studentToDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}