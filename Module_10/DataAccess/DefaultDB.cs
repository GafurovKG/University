namespace DataAccess
{
    using DataAccess.Models;

    internal static class DefaultDB
    {
        public static void CreateDafaultDB(UniverDbContext studentContext)
        {
            studentContext.Database.EnsureDeleted();
            studentContext.Database.EnsureCreated();

            var student1 = new StudentDb { Name = "Hary Potter", Email = "Harry@hogvards.uk", Tel = "8800200600" };
            var student2 = new StudentDb { Name = "Pinocio", Email = "buratino@sherwood.uk", Tel = "88002200601" };
            var student3 = new StudentDb { Name = "Neznaika", Email = "what@neverhood.xz", Tel = "880022006602" };
            studentContext.Students.AddRange(student1, student2, student3);

            var lector1 = new LectorDb { Name = "Damboldor", Email = "Dam@hogvards.uk" };
            var lector2 = new LectorDb { Name = "Leo Tolstoy", Email = "leo@ya_poliyna.ru" };
            studentContext.Lectors.AddRange(lector1, lector2);

            var lecture1 = new LectureDb { LectureTheme = "Strings", IsReaded = true };
            var lecture2 = new LectureDb { LectureTheme = "Classes", IsReaded = true };
            var lecture3 = new LectureDb { LectureTheme = "Records", IsReaded = true };
            var lecture4 = new LectureDb { LectureTheme = "Interfaces", IsReaded = true };
            var lecture5 = new LectureDb { LectureTheme = "OOP" };
            var lecture6 = new LectureDb { LectureTheme = "Events" };
            var lecture7 = new LectureDb { LectureTheme = "Lambda" };
            studentContext.Lectures.AddRange(lecture1, lecture2, lecture3, lecture4, lecture5, lecture6, lecture7);
            studentContext.SaveChanges();

            var homework1 = new HomeWorkDb { HWDescription = "Strings?", Lecture = lecture1 };
            var homework2 = new HomeWorkDb { HWDescription = "Classes?", Lecture = lecture2 };
            var homework3 = new HomeWorkDb { HWDescription = "Records?", Lecture = lecture3 };
            var homework4 = new HomeWorkDb { HWDescription = "Interfaces", Lecture = lecture4 };
            var homework5 = new HomeWorkDb { HWDescription = "OOP?", Lecture = lecture5 };
            var homework6 = new HomeWorkDb { HWDescription = "Events?", Lecture = lecture6 };
            var homework7 = new HomeWorkDb { HWDescription = "Lambda?", Lecture = lecture7 };
            studentContext.HomeWorks.AddRange(homework1, homework2, homework3, homework4, homework5, homework6, homework7);

            student1.AttendanceLog.AddRange(new List<AttendanceLog>
            {
                new AttendanceLog { Lecture = lecture1, HomeWorkMark = 5 },
                new AttendanceLog { Lecture = lecture2, HomeWorkMark = 4 },
                new AttendanceLog { Lecture = lecture3, HomeWorkMark = 5 },
                new AttendanceLog { Lecture = lecture4, HomeWorkMark = 4 },
            });

            student2.AttendanceLog.AddRange(new List<AttendanceLog>
            {
                new AttendanceLog { Lecture = lecture1, HomeWorkMark = 3 },
                new AttendanceLog { Lecture = lecture2, HomeWorkMark = 3 },
            });

            student3.AttendanceLog.AddRange(new List<AttendanceLog>
            {
                new AttendanceLog { Lecture = lecture1, HomeWorkMark = 4 },
            });
            studentContext.SaveChanges();
        }
    }
}