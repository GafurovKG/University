namespace WebApi.Controllers
{
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("/api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsService studentService;

        public StudentController(IStudentsService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            return studentService.Get(id) switch
            {
                null => NotFound(),
                var student => student
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<Student>> GetStudents()
        {
            return studentService.GetAll().ToArray();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var newStudentId = studentService.New(student with { Id = 0 });
            return Ok($"api/student/{newStudentId}\n" +
                $"{studentService.Get(newStudentId)}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateStudent(int id, Student student)
        {
            var studentId = studentService.Edit(student with { Id = id });
            return Ok($"api/student/{studentId}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            studentService.Delete(id);
            return Ok();
        }
    }
}