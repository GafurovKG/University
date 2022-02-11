namespace WebApi.Controllers
{
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("/api/homework")]
    public class HomeWorkController : ControllerBase
    {
        private readonly IUniverService<HomeWorkDb> homeWorkService;

        public HomeWorkController(IUniverService<HomeWorkDb> univerService)
        {
            this.homeWorkService = univerService;
        }

        [HttpGet("{id}")]
        public ActionResult<HomeWorkDb> GetHomeWork(int id)
        {
            return homeWorkService.Get(id) switch
            {
                null => NotFound(),
                var homework => homework
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<HomeWorkDb>> GetHomeWorks()
        {
            return homeWorkService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult AddHomeWork(HomeWorkDb homeWork)
        {
            var newHomeWorkId = homeWorkService.New(homeWork with { Id = 0 });
            return Ok($"api/homework/{newHomeWorkId}\n" +
                $"{homeWorkService.Get(newHomeWorkId)}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdatenewHomeWorkId(int id, HomeWorkDb homeWork)
        {
            homeWorkService.Edit(homeWork with { Id = id });
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