using API.Business;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestController : Controller
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost("veri/{musteriAdet}/{sepetAdet}")]
        public void TestVerisiOlustur(int musteriAdet,int sepetAdet)
        {
            _testService.TestVerisiOlustur(musteriAdet, sepetAdet);
        }

    }
}
