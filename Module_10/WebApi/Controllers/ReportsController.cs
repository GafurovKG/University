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
        private readonly IReportService reportService;
        private readonly IMapper mapper;

        public ReportsController(IReportService reportService, IMapper mapper)
        {
            this.reportService = reportService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReportLogUI>> GetReport(string paramstring)
        {
            var reuslt = reportService.GetReport(paramstring);
            return mapper.Map<IReadOnlyCollection<ReportLogUI>>(reuslt).ToList();
        }
    }
}