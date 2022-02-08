namespace DataAccess
{
    using AutoMapper;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    internal class StudentsRepository<TEntity> : IStudentsRepository<TEntity> where TEntity : class
    {
        private readonly StudentDbContext context;
        private readonly IMapper mapper;

        public StudentsRepository(StudentDbContext studentContext, IMapper mapper)
        {
            context = studentContext;
            this.mapper = mapper;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var studentDb = context.Set<TEntity>().ToList();
            return mapper.Map<IReadOnlyCollection<TEntity>>(studentDb);
        }

        public TEntity? Get(int id)
        {
            var studentDb = context.Set<TEntity>().Find(id);
            return mapper.Map<TEntity?>(studentDb);
        }

        public int New(TEntity student)
        {
            var studentDb = mapper.Map<TEntity>(student);
            var result = context.Set<TEntity>().Add(studentDb);
            context.SaveChanges();
            return 1000;
            //return result.Entity.Id;
        }

        public void Edit(TEntity student)
        {
            //if (context.Students.Find(student.Id) is StudentDb studentInDb)
            //{
                //studentInDb.Name = student.Name;
                //studentInDb.Email = student.Email;
                context.Entry(student).State = EntityState.Modified;
                context.SaveChanges();
            //}
        }

        public void Delete(int id)
        {
            var studentToDelete = context.Set<TEntity>().Find(id);
            context.Entry(studentToDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}