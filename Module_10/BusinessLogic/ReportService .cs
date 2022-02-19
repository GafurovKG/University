using DataAccess;
using DataAccess.Models;

namespace BusinessLogic
{
    internal class RepotrService : IReportService
    {
        private readonly IReportRepository reportRepository;
        private readonly IUniverRepository<StudentDb> studentRepository;
        private readonly IUniverRepository<LectureDb> lectureRepository;

        public RepotrService(
            IReportRepository reportRepository,
            IUniverRepository<StudentDb> studentRepository,
            IUniverRepository<LectureDb> lectureRepository)
        {
            this.reportRepository = reportRepository;
            this.lectureRepository = lectureRepository;
            this.studentRepository = studentRepository;
        }

        public IReadOnlyCollection<AttendanceLog> GetReport(string paramstring)
        {
            var parametrs = paramstring
                .Split('-')
                .Where(x => x != "")
                .ToLookup(x => x.Split(' ')[0], x => x.Substring(x.IndexOf(' '))
                .Trim());
            var sort = "student";
            var sortASC = true;
            var response = new List<AttendanceLog>();

            foreach (var item in parametrs)
            {
                switch (item.Key)
                {
                    case "student":
                        var students = studentRepository.GetAll();
                        foreach (var name in item)
                        {
                            var studentId = students
                            .Where(x => x.Name.Equals(name))
                            .Select(x => x.Id).Single();
                            response.AddRange(reportRepository.GetStudent(studentId).ToList());

                            //var res = reportRepository.GetAll().GroupJoin(
                            //studentRepository.GetAll(), r => r.StudentId, s => s.Id, (r, s) => new { r, s }).
                            //SelectMany(x => x.s.DefaultIfEmpty(),
                            //(reprecord, student) => new { studentId = reprecord.r.StudentId, studentName = student.Name });
                        }

                        break;
                    case "lecture":
                        var lectures = lectureRepository.GetAll();
                        foreach (var theme in item)
                        {
                            var lectureId = lectures
                            .Where(x => x.LectureTheme.Equals(theme))
                            .Select(x => x.Id).Single();
                            response.AddRange(reportRepository.GetLecture(lectureId).ToList());
                        }

                        break;
                    case "sort":
                        foreach (var sortparam in item)
                        {
                            var temp = sortparam.ToString().Split(' ')[0];
                            sort = Convert.ToString(temp[0]).ToUpper() + temp.Substring(1, temp.Length - 1);
                            if (sortparam.Contains("dsc"))
                            {
                                sortASC = false;
                            }
                        }

                        break;
                    default:
                        Console.WriteLine($"Введен неизвестный параметр: -{item.Key} {item}");
                        throw new Exception($"Введен неизвестный параметр: -{item.Key} {item}");
                        break;
                }
            }

            var propertyInfo = typeof(AttendanceLog).GetProperty(sort);

            if (sortASC)
            {
                response.OrderBy(x => propertyInfo?.GetValue(x, null));
            }
            else
            {
                response.OrderByDescending(x => propertyInfo?.GetValue(x, null));
            }

            return response.ToArray();
        }

    }
}