using API.Business;
using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public List<DtoSehirAnaliz> SehirBazlıAnalizYap()
        {
            return _reportService.SehirBazlıAnalizYap();
        }
    }
}
