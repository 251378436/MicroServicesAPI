using Amazon.DynamoDBv2.DataModel;
using API2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public ProductController(IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
        }

        [Route("getnew")]
        [HttpGet]
        public async Task<IActionResult> GetNew()
        {
            try
            {
                var prod = new Product2
                {
                    MessageId = Guid.NewGuid().ToString(),
                    Received = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK"),
                    Description = "from miscroservices2",
                    Price = 12
                };

                var json = System.Text.Json.JsonSerializer.Serialize(prod);

                prod.Message = json;

                await _dynamoDBContext.SaveAsync(prod);
                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}