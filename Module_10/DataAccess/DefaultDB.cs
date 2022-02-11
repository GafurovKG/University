namespace DataAccess
{
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    internal static class DefaultDB
    {
        public static void CreateDafaultDB(UniverDbContext studentContext)
        {
            studentContext.Database.EnsureDeleted();
            studentContext.Database.EnsureCreated();

            var student1 = new StudentDb { Name = "Hary Potter", Email = "Harry@hogvards.uk", Tel = "8800200600" };
            var student2 = new StudentDb { Name = "Pinocio", Email = "buratino@sherwood.uk", Tel = "88002200660" };
            studentContext.Students.AddRange(student1, student2);

            var lector1 = new LectorDb { Name = "Damboldor", Email = "Dam@hogvards.uk" };
            var lector2 = new LectorDb { Name = "Leo Tolstoy", Email = "leo@ya_poliyna.ru" };
            studentContext.Lectors.AddRange(lector1, lector2);

            var lecture1 = new LectureDb { Theme = "Pi", Lector = lector1};
            var lecture2 = new LectureDb { Theme = "Sin", Lector = lector2};
            studentContext.Lectures.AddRange(lecture1, lecture2);

            var homework1 = new HomeWorkDb { Description = "How is Pi?", Lecture = lecture1 };
            var homework2 = new HomeWorkDb { Description = "Sin or Cos?", Lecture = lecture2 };
            studentContext.HomeWorks.AddRange(homework1, homework2);

            lecture1.VisitedStudents.Add(student1);
            lecture2.VisitedStudents.AddRange( new List<StudentDb> { student1, student2 });

            student1.AttendanceLog.Add(new AttendanceLog { Lecture = lecture1, Mark = 5 });
            student1.AttendanceLog.Add(new AttendanceLog { Lecture = lecture2, Mark = 4 });
            student2.AttendanceLog.Add(new AttendanceLog { Lecture = lecture1, Mark = 3 });

            studentContext.SaveChanges();
        }
    }
}