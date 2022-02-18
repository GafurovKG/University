using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    internal class UniverLinkService : IUniverLinkService
    {
        private readonly IUniverService<StudentDb> studentservice;
        private readonly IUniverService<HomeWorkDb> hwservice;
        private readonly IUniverService<LectureDb> lectureservice;
        private readonly IUniverService<AttendanceLog> attendanceLogservice;

        public UniverLinkService(IUniverService<StudentDb> studentservice, IUniverService<HomeWorkDb> hwservice, IUniverService<LectureDb> lectionservice, IUniverService<AttendanceLog> attendanceLogservice)
        {
            this.studentservice = studentservice;
            this.hwservice = hwservice;
            this.lectureservice = lectionservice;
            this.attendanceLogservice = attendanceLogservice;
        }

        public int NewHW(int lectureId, HomeWorkDb homeWork)
        {
            var lecture = lectureservice.Get(lectureId);
            homeWork.Lecture = lecture;
            homeWork.LectureId = lectureId;
            var newHWId = hwservice.New(homeWork);
            lecture.HomeWork = hwservice.Get(newHWId);
            lectureservice.Edit(lecture);
            return newHWId;
        }

        public void EditHW(HomeWorkDb homeWork)
        {
            var currentHomeWork = hwservice.Get(homeWork.Id);
            currentHomeWork.HWDescription = homeWork.HWDescription;
            hwservice.Edit(currentHomeWork);
        }

        public IReadOnlyCollection<AttendanceLog> GetReport(string paramstring)
        {
            var parametrs = paramstring
                .Split('-')
                .Where(x => x != "")
                .ToDictionary(x => x.Split(' ')[0], x => x.Substring(x.IndexOf(' '))
                .Trim());
            var studentName = "";
            var lectureTheme = "";
            var sort = "student";
            var sortASC = true;

            foreach (var item in parametrs)
            {
                switch (item.Key)
                {
                    case "student":
                        studentName = item.Value;
                        break;
                    case "lecture":
                        lectureTheme = item.Value;
                        break;
                    case "sort":
                        var temp = item.Value.Split(' ')[0];
                        sort = Convert.ToString(temp[0]).ToUpper() + temp.Substring(1, temp.Length - 1);
                        if (item.Value.Contains("dsc"))
                        {
                            sortASC = false;
                        }

                        break;
                    default:
                        Console.WriteLine($"Введен неизвестный параметр: -{item.Key} {item.Value}");
                        break;
                }
            }

            var attendancelog = attendanceLogservice.GetAll().ToArray();
            for (int i = 0; i < attendancelog.Length; i++)
            {
                attendancelog[i].Student = studentservice.Get(attendancelog[i].StudentId);
                attendancelog[i].Lecture = lectureservice.Get(attendancelog[i].LectureId);
            }

            var response = attendancelog
                .Where(x => x.Student.Name.Contains(studentName))
                .Where(x => x.Lecture.LectureTheme.Contains(lectureTheme));

            var propertyInfo = typeof(AttendanceLog).GetProperty(sort);

            if (sortASC)
            {
                response = response.OrderBy(x => propertyInfo?.GetValue(x, null));
            }
            else
            {
                response = response.OrderByDescending(x => propertyInfo?.GetValue(x, null));
            }

            return response.ToArray();
        }

    }
}