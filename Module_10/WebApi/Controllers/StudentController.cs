namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UIModels;

    [ApiController]
    [Route("/api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IUniverService<StudentDb> studentService;
        private readonly IMapper mapper;

        public StudentController(IUniverService<StudentDb> univerService, IMapper mapper)
        {
            this.studentService = univerService;
            this.mapper = mapper;
        }

/*        [HttpGet("{id}")]
        public ActionResult<StudentUI> GetStudent(int id)
        {
            return studentService.Get(id) switch
            {
                null => NotFound(),
                var student => mapper.Map<StudentUI>(student)
            };
        }*/

        [HttpGet]
        public ActionResult<IReadOnlyCollection<StudentUI>> GetStudents()
        {
            var result = studentService.GetAll().ToArray();
            return mapper.Map<IReadOnlyCollection<StudentUI>>(result).ToList();
        }

/*        [HttpPost]
        public ActionResult AddStudent(StudentUIPost student)
        {
            var newStudentId = studentService.New(mapper.Map<StudentDb>(student));
            return Ok($"api/student/{newStudentId}\n" +
                $"{studentService.Get(newStudentId)}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateStudent(int id, StudentUIPost student)
        {
            studentService.Edit(mapper.Map<StudentDb>(student) with { Id = id });
            return Ok($"api/student/{id}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            studentService.Delete(id);
            return Ok();
        }*/
    }
}