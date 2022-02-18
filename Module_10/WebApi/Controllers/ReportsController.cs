namespace WebApi.Controllers
{
    using AutoMapper;
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UIModels;

    [ApiController]
    [Route("/api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IUniverLinkService linkService;
        private readonly IMapper mapper;

        public ReportsController(IUniverLinkService linkService, IMapper mapper)
        {
            this.linkService = linkService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<AttendanceLog>> GetReport(string paramstring)
        {
            var reuslt = linkService.GetReport(paramstring);
            return reuslt.ToList();
        }
    }
}