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

            var lecture1 = new LectureDb { LectureTheme = "Pi"};
            var lecture2 = new LectureDb { LectureTheme = "Sin"};
            studentContext.Lectures.AddRange(lecture1, lecture2);
            studentContext.SaveChanges();

            var homework1 = new HomeWorkDb { HWDescription = "How is Pi?", Lecture = lecture1, LectureId = 1 };
            var homework2 = new HomeWorkDb { HWDescription = "Sin or Cos?", Lecture = lecture2, LectureId = 2 };
            studentContext.HomeWorks.AddRange(homework1, homework2);

            lecture1.VisitedStudents.Add(student1);
            lecture2.VisitedStudents.AddRange( new List<StudentDb> { student1, student2 });

            //student1.AttendanceLog.Add(new AttendanceLog { Lecture = lecture1, Mark = 5 });
            //student1.AttendanceLog.Add(new AttendanceLog { Lecture = lecture2, Mark = 4 });
            //student2.AttendanceLog.Add(new AttendanceLog { Lecture = lecture1, Mark = 3 });

            studentContext.SaveChanges();
        }
    }
}