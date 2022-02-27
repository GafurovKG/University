using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using WebApi;
using WebApi.UIModels;

namespace LectureController.IntegrationTest
{
    [TestFixture]
    public class LectureControllerTests
    {
        private int lectureId;
        private UniverDbContext dbContext = null!;
        private WebApplicationFactory<Startup> webHost = null!;

        private LectureDb notReadLectureInDb = null!;
        private LectureDb readLectureInDb = null!;
        private StudentDb inDbStudent = null!;

        private List<AttendanceRecordUI> visitedStudents = null!;
        private HttpClient httpClient = null!;
        private HttpContent content = null!;

        [OneTimeSetUp]
        public async Task Setup()
        {
            webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<UniverDbContext>));
                    services.Remove(dbContextDescriptor);
                    services.AddDbContext<UniverDbContext>(options => options.UseInMemoryDatabase("UniverInMemoryDb"));
                });
            });
            dbContext = webHost.Services.CreateScope().ServiceProvider.GetService<UniverDbContext>();
            notReadLectureInDb = new LectureDb { Id = 1, IsReaded = false, LectureTheme = "tests" };
            readLectureInDb = new LectureDb { Id = 2, IsReaded = true, LectureTheme = "tests" };
            await dbContext.Lectures.AddRangeAsync(notReadLectureInDb, readLectureInDb);
            await dbContext.SaveChangesAsync();
            inDbStudent = new StudentDb { Id = 1, Name = "Alf", Email = "alfMail", Tel = "80800" };
            await dbContext.Students.AddRangeAsync(inDbStudent);
            await dbContext.SaveChangesAsync();

            visitedStudents = new List<AttendanceRecordUI>
            {
                new AttendanceRecordUI { StudentId = 1, Mark = 5 },
            };
            string json = JsonConvert.SerializeObject(visitedStudents);
            content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient = webHost.CreateClient();
        }

        [Test]
        public async Task LectureIsRead_LectureNotRead_ShouldResultOk()
        {
            // Arrange
            lectureId = notReadLectureInDb.Id;

            // Act

            HttpResponseMessage response = await httpClient.PutAsync($"api/lecture/lectureIsReaded?id={lectureId}", content);

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.OK, actual: response.StatusCode);
        }

        [Test]
        public async Task LectureIsRead_LectureWasRead_Resoult500()
        {
            // Arrange
            lectureId = readLectureInDb.Id;

            // Act

            HttpResponseMessage response = await httpClient.PutAsync($"api/lecture/lectureIsReaded?id={lectureId}", content);

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.InternalServerError, actual: response.StatusCode);
        }

        [Test]
        public async Task LectureIsRead_NotStudentinDb_Resoult404()
        {
            // Arrange
            lectureId = notReadLectureInDb.Id;
            var unnounStudents = new List<AttendanceRecordUI>
            {
                new AttendanceRecordUI { StudentId = 500, Mark = 5 },
            };
            string json = JsonConvert.SerializeObject(unnounStudents);
            content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Act

            HttpResponseMessage response = await httpClient.PutAsync($"api/lecture/lectureIsReaded?id={lectureId}", content);

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.NotFound, actual: response.StatusCode);
        }
    }
}