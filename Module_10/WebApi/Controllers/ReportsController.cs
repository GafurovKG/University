namespace WebApi.Controllers
{
    using AutoMapper;
    using DataAccess;
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

        [HttpPost("selectedattendancelog")]
        public ActionResult<IEnumerable<ReportLogUI>> GetReport([FromQuery] string[] students, [FromQuery] string[] lectures)
        {
            var reuslt = reportService.GetReport(students, lectures);
            return mapper.Map<IEnumerable<ReportLogUI>>(reuslt).ToList();
        }

        [HttpGet("allattendancelog")]
        public ActionResult<IEnumerable<ReportLogUI>> GetFullReport()
        {
            var reuslt = reportService.GetReport();
            return mapper.Map<IEnumerable<ReportLogUI>>(reuslt).ToList();
        }
    }
}