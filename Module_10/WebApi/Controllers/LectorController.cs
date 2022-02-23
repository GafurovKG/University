namespace WebApi.Controllers
{
    using AutoMapper;
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UIModels;

    [ApiController]
    [Route("/api/lector")]
    public class LectorController : ControllerBase
    {
        private readonly IUniverService<LectorDb> lectorService;
        private readonly IMapper mapper;

        public LectorController(IUniverService<LectorDb> univerService, IMapper mapper)
        {
            this.lectorService = univerService;
            this.mapper = mapper;
        }

        //[HttpGet("{id}")]
        //public ActionResult<LectorUI> GetLector(int id)
        //{
        //    return lectorService.Get(id) switch
        //    {
        //        null => NotFound(),
        //        var lector => mapper.Map<LectorUI>(lector)
        //    };
        //}

        [HttpGet]
        public ActionResult<IReadOnlyCollection<LectorUI>> GetLectors()
        {
            var result = lectorService.GetAll().ToArray();
            return mapper.Map<IReadOnlyCollection<LectorUI>>(result).ToList();
        }

        //[HttpPost]
        //public ActionResult AddLector(LectorUIPost lector)
        //{
        //    var newLectorId = lectorService.New(mapper.Map<LectorDb>(lector));
        //    return Ok($"api/lector/{newLectorId}");
        //}

        //[HttpPut("{id}")]
        //public ActionResult<string> UpdateLector(int id, LectorUIPost lector)
        //{
        //    lectorService.Edit(mapper.Map<LectorDb>(lector) with { Id = id });
        //    return Ok($"api/lector/{id}");
        //}

        //[HttpDelete("{id}")]
        //public ActionResult DeleteLector(int id)
        //{
        //    lectorService.Delete(id);
        //    return Ok();
        //}
    }
}