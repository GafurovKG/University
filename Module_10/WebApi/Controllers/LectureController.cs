namespace WebApi.Controllers
{
    using AutoMapper;
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UIModels;

    [ApiController]
    [Route("/api/lecture")]
    public class LectureController : ControllerBase
    {
        private readonly IUniverService<LectureDb> lectureService;
        private readonly IMapper mapper;

        public LectureController(IUniverService<LectureDb> univerService, IMapper mapper)
        {
            this.lectureService = univerService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<LectureDb> GetLecture(int id)
        {
            return lectureService.Get(id) switch
            {
                null => NotFound(),
                var lecture => lecture
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<LectureDb>> GetLecture()
        {
            return lectureService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult AddStudent(LectureUIPost lecture)
        {
            var newLectureId = lectureService.New(mapper.Map<LectureDb>(lecture) with { Id = 0 });
            return Ok($"api/lecture/{newLectureId}\n" +
                $"{lectureService.Get(newLectureId)}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateLecture(int id, LectureDb lecure)
        {
            lectureService.Edit(lecure with { Id = id });
            return Ok($"api/lecture/{id}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLecture(int id)
        {
            lectureService.Delete(id);
            return Ok();
        }
    }
}