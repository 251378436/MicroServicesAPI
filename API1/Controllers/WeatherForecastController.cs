using Base;
using Microsoft.AspNetCore.Mvc;
using API1.Models;
using System.Text.Json;
using System.Diagnostics;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Creates a account.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost(Name = "GetWeatherForecast")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        public async Task<IActionResult> Get([FromBody]RequestModel requestModel)
        {
            //throw new Exception("3333333333333333");
            _logger.LogInformation($"************* Thread ID:{Thread.CurrentThread.ManagedThreadId} *****************");
            _logger.LogInformation("Information ***********");
            _logger.LogCritical("Critical @###############SSSSSSSSSSS");
            var ttt1 = requestModel.BirthDay.GetValueOrDefault().ToString("yyyy-MM-dd");
            var t1 = "2022-06-24T06:51:31.4294718-12:00";
            var r1 = DateTime.Parse(t1);
            var k1 = r1.ToString("yyyy-MM-dd");

            DateTime dt1 = new DateTime(2015, 12, 31);
            var s1 = dt1.ToString();

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            var list = Enumerable.Range(1, 1).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            var json = JsonSerializer.Serialize(list);
            var result = new ResponseModel();
            result.RequestId = "12345asbcd";
            result.BirthDay = DateTime.Now;
            return Ok(requestModel);
        }

        [HttpGet("test/{testid:int}/ids", Name = "TesPost")]
        public async Task<IActionResult> PostTest(int testid, CancellationToken cancellationToken)
        {
            await Task.Delay(10000);
            if (cancellationToken.IsCancellationRequested)
            {
                Debug.WriteLine("***********************");
                
                throw new TaskCanceledException("eeeeeeee");
            }
            return Ok(1000);
        }
    }
}