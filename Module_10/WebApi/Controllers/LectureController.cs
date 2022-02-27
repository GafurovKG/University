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

/*        [HttpGet("{id}")]
        public ActionResult<LectureUI> GetLecture(int id)
        {
            return lectureService.Get(id) switch
            {
                null => NotFound(),
                var lecture => mapper.Map<LectureUI>(lecture)
            };
        }*/

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

/*        [HttpPut("{id}")]
        public ActionResult<string> UpdateLecture(int id, LectureUIPost lecture)
        {
            lectureService.Edit(mapper.Map<LectureDb>(lecture) with { Id = id });
            return Ok($"api/lecture/{id}");
        }*/

        [HttpPut("lectureIsReaded")]
        public IActionResult LectureIsRead(int id, List<AttendanceRecordUI> visitedStudents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = linkService.CreateAttendanceRecord(id, mapper.Map<List<AttendanceRecord>>(visitedStudents).AsQueryable());
            return Ok($"api/lecture/lectureIsReaded/{result.Id}");
        }

/*        [HttpDelete("{id}")]}
        public ActionResult DeleteLecture(int id)
        {
            lectureService.Delete(id);
            return Ok();
        }*/
    }
}