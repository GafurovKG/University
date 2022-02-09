namespace WebApi.Controllers
{
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("/api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IUniverService<StudentDb> studentService;

        public StudentController(IUniverService<StudentDb> univerService)
        {
            this.studentService = univerService;
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDb> GetStudent(int id)
        {
            return studentService.Get(id) switch
            {
                null => NotFound(),
                var student => student
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<StudentDb>> GetStudents()
        {
            return studentService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDb student)
        {
            var newStudentId = studentService.New(student with { Id = 0 });
            return Ok($"api/student/{newStudentId}\n" +
                $"{studentService.Get(newStudentId)}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateStudent(int id, StudentDb student)
        {
            studentService.Edit(student with { Id = id });
            return Ok($"api/student/{id}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            studentService.Delete(id);
            return Ok();
        }
    }
}