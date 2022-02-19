namespace DataAccess
{
    using AutoMapper;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    internal class ReportRepository : IReportRepository

    {
        private readonly UniverDbContext context;
        private readonly IMapper mapper;

        public ReportRepository(UniverDbContext UniverContext, IMapper mapper)
        {
            context = UniverContext;
            this.mapper = mapper;
        }

        public IEnumerable<AttendanceLog> GetAll()
        {
            var response = context.Set<AttendanceLog>()
                .Include(x => x.Lecture)
                .Include( x => x.Student)
                .ToList();
            return response;
        }

        public IEnumerable<AttendanceLog> GetStudent(int studentId)
        {
            var response = context.Set<AttendanceLog>()
                .Where(x => x.StudentId.Equals(studentId))
                .Include(x => x.Student)
                .Include(x => x.Lecture)
                .ToList();
            return response;
        }
        public IEnumerable<AttendanceLog> GetLecture(int lectureId)
        {
            var response = context.Set<AttendanceLog>()
                .Where(x => x.LectureId.Equals(lectureId))
                .Include(x => x.Student)
                .Include(x => x.Lecture)
                .ToList();
            return response;
        }

        public IEnumerable<AttendanceLog> GetSeveral(int[] ids)
        {
            var db = context.Set<AttendanceLog>().Where(x => x.Id.Equals(ids));
            return mapper.Map<IEnumerable<AttendanceLog>>(db);
        }

        public int New(AttendanceLog record)
        {
            var dbEntity = mapper.Map<AttendanceLog>(record);
            var result = context.Set<AttendanceLog>().Add(dbEntity);
            context.SaveChanges();
            return result.Entity.Id;
        }

        public void Edit(AttendanceLog record)
        {
                context.Entry(record).State = EntityState.Modified;
                context.SaveChanges();
        }

        //public void Delete(int id)
        //{
        //    var entityToDelete = context.Set<TEntity>().Find(id);
        //    context.Entry(entityToDelete).State = EntityState.Deleted;
        //    context.SaveChanges();
        //}
    }
}