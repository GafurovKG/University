namespace WebApi.Controllers
{
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("/api/lector")]
    public class LectorController : ControllerBase
    {
        private readonly IUniverService<LectorDb> lectorService;

        public LectorController(IUniverService<LectorDb> univerService)
        {
            this.lectorService = univerService;
        }

        [HttpGet("{id}")]
        public ActionResult<LectorDb> GetLector(int id)
        {
            return lectorService.Get(id) switch
            {
                null => NotFound(),
                var lector => lector
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<LectorDb>> GetLectors()
        {
            return lectorService.GetAll().ToArray();
        }

        [HttpPost]
        public ActionResult AddLector(LectorDb lector)
        {
            var newLectorId = lectorService.New(lector with { Id = 0 });
            return Ok($"api/lector/{newLectorId}\n" +
                $"{lectorService.Get(newLectorId)}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateLector(int id, LectorDb lector)
        {
            lectorService.Edit(lector with { Id = id });
            return Ok($"api/lector/{id}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLector(int id)
        {
            lectorService.Delete(id);
            return Ok();
        }
    }
}