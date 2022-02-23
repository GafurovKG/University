namespace WebApi.Controllers
{
    using AutoMapper;
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UIModels;

    [ApiController]
    [Route("/api/homework")]
    public class HomeWorkController : ControllerBase
    {
        private readonly IUniverService<HomeWorkDb> homeWorkService;
        private readonly IUniverLinkService linkService;
        private readonly IMapper mapper;

        public HomeWorkController(IUniverService<HomeWorkDb> univerService, IUniverLinkService linkService, IMapper mapper)
        {
            this.homeWorkService = univerService;
            this.linkService = linkService;
            this.mapper = mapper;
        }

/*      [HttpGet("{id}")]
        public ActionResult<HomeWorkUI> GetHomeWork(int id)
        {
            return homeWorkService.Get(id) switch
            {
                null => NotFound(),
                var homework => mapper.Map<HomeWorkUI>(homework)
            };
        }*/

        [HttpGet]
        public ActionResult<IReadOnlyCollection<HomeWorkUI>> GetHomeWorks()
        {
            var result = homeWorkService.GetAll().ToArray();
            return mapper.Map<IReadOnlyCollection<HomeWorkUI>>(result).ToList();
        }

        [HttpPost("addHWToLecture")]
        public ActionResult AddHomeWork(int lectureid, HomeWorkUIPost homeWork)
        {
            var newHomeWorkId = linkService.NewHW(lectureid, mapper.Map<HomeWorkDb>(homeWork));
            return Ok($"api/homework/{newHomeWorkId}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> EditHomeWork(int id, HomeWorkUIPost homeWork)
        {
            linkService.EditHW(mapper.Map<HomeWorkDb>(homeWork) with { Id = id });
            return Ok($"api/homework/{id}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteHomeWork(int id)
        {
            homeWorkService.Delete(id);
            return Ok();
        }
    }
}