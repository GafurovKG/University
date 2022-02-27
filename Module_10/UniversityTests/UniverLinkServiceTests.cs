using NUnit.Framework;
using BusinessLogic;
using Moq;
using DataAccess.Models;
using System.Linq;
using DataAccess;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using BusinessLogic.Exceptions;

namespace UniversityTests
{
    [TestFixture]
    public class Tests
    {
        private Mock<IUniverService<LectureDb>> mockLectureService = null!;
        private Mock<IUniverService<HomeWorkDb>> mockHWService = null!;
        private Mock<IReportRepository> mockReportRepository = null!;
        private Mock<ILogger<UniverLinkService>> mockLogger = null!;
        private IUniverLinkService linkService = null!;

        [SetUp]
        public void Setup()
        {
            mockLectureService = new Mock<IUniverService<LectureDb>>();
            mockHWService = new Mock<IUniverService<HomeWorkDb>>();
            mockReportRepository = new Mock<IReportRepository>();
            mockLogger = new Mock<ILogger<UniverLinkService>>();

            linkService = new UniverLinkService(
                mockHWService.Object,
                mockLectureService.Object,
                mockReportRepository.Object,
                mockLogger.Object);
        }

        [Test]
        public void CreateAttendanceRecord_notInputData_Exception()
        {
            mockReportRepository.Setup(a => a.GetLinkedLecture(0)).Returns(new LectureDb { IsReaded = true });
            mockReportRepository.Setup(a => a.GetLinkedLecture(1)).Returns(new LectureDb { IsReaded = false });

            Assert.Throws<LectureWasReadExceptions>(() => linkService.CreateAttendanceRecord(0, new List<AttendanceRecord>().AsQueryable()));
        }

        [Test]
        public void CreateAttendanceRecord_EdiLecture()
        {
            var readLecture = new LectureDb { IsReaded = false, Id = 1 };
            var attendanceRecord = new List<AttendanceRecord>
            {
                new AttendanceRecord { Mark = 5, StudentId = 1 },
                new AttendanceRecord { Mark = 4, StudentId = 2 }
            }.AsQueryable();

            var stud1 = new StudentDb { Id = 1 };
            var stud2 = new StudentDb { Id = 2 };

            var expected = new List<AttendanceLog>
            {
                new AttendanceLog { StudentId = 1, HomeWorkMark = 5, LectureId = 1, Student = stud1 },
                new AttendanceLog { StudentId = 2, HomeWorkMark = 4, LectureId = 1, Student = stud2 }
            };

            mockReportRepository.Setup(a => a.GetLinkedLecture(1)).Returns(readLecture);
            mockLectureService.Setup(a => a.Edit(readLecture)).Returns(2);
            mockReportRepository.Setup(a => a.GetSeveralLinkedStudents(new int[] { 1, 2 }))
                .Returns(new List<StudentDb> { stud1, stud2 });
            var result = linkService.CreateAttendanceRecord(readLecture.Id, attendanceRecord);

            Assert.AreEqual(expected, result.AttendanceLog);
        }
    }

}