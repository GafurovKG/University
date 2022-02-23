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
        private readonly IUniverLinkService linkService;
        private readonly IMapper mapper;

        public LectureController(IUniverLinkService linkService, IUniverService<LectureDb> univerService, IMapper mapper)
        {
            this.linkService = linkService;
            this.lectureService = univerService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<LectureUI> GetLecture(int id)
        {
            return lectureService.Get(id) switch
            {
                null => NotFound(),
                var lecture => mapper.Map<LectureUI>(lecture)
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<LectureUI>> GetLecture()
        {
             var result = lectureService.GetAll().ToArray();
             return mapper.Map<IReadOnlyCollection<LectureUI>>(result).ToList();
        }

        [HttpPost]
        public ActionResult<LectureUI> AddStudent(LectureUIPost lecture)
        {
            var newLectureId = lectureService.New(mapper.Map<LectureDb>(lecture));
            return Ok($"api/lecture/{newLectureId}");
        }

        //[HttpPut("{id}")]
        //public ActionResult<string> UpdateLecture(int id, LectureUIPost lecture)
        //{
        //    lectureService.Edit(mapper.Map<LectureDb>(lecture) with { Id = id });
        //    return Ok($"api/lecture/{id}");
        //}

        [HttpPut("{id}")]
        public ActionResult<string> ReadLecture(int id, [FromQuery]List<int> students, [FromQuery] List<int> marks)
        {
            var inst = linkService.NewAttendanceRecord(id, students, marks);
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