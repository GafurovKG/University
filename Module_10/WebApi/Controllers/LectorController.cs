namespace WebApi.Controllers
{
    using Domain;
    using Domain.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("/api/lector")]
    public class LectorController : ControllerBase
    {
        private readonly IStudentsService<Lector> studentService;

        public LectorController(IStudentsService<Lector> studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("{id}")]
        public ActionResult<Lector> GetStudent(int id)
        {
            return studentService.Get(id) switch
            {
                null => NotFound(),
                var student => student
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<Lector>> GetStudents()
        {
            return studentService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult AddStudent(Lector student)
        {
            var newStudentId = studentService.New(student with { Id = 0 });
            return Ok($"api/lector/{newStudentId}\n" +
                $"{studentService.Get(newStudentId)}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateStudent(int id, Lector student)
        {
            studentService.Edit(student with { Id = id });
            return Ok($"api/lector/{id}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            studentService.Delete(id);
            return Ok();
        }
    }
}