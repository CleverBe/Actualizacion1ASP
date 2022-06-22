using ApiCompetencia.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompetencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService service)
        {
            _testService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_testService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var test = _testService.Get(id);
            if (test == null)
                return NotFound();

            return Ok(test);
        }
    }
}
