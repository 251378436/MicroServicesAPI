using API2.Configuration;
using API2.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API2.Controllers
{
    [ServiceFilter(typeof(CookieFilter))]
    [ResponseCache(Duration = 60)]
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly Api2Settings _api2Settings;

        public InformationController(IOptionsSnapshot<Api2Settings> api2SettingsOptions)
        {
            _api2Settings = api2SettingsOptions.Value;
        }

        [HttpGet]
        public IActionResult GetVersion()
        {
            return Ok("1.0.0");
        }

        [HttpGet("settings")]
        public IActionResult GetSettings()
        {
            return Ok(_api2Settings);
        }

        [HttpGet("utctime")]
        public IActionResult GetCurrentUTCTime()
        {
            return Ok(DateTime.UtcNow);
        }
    }
}
