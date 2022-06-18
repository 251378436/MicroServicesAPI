using API2.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using Xunit;

namespace API2.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var a = 123;
        var b = 123;
        Assert.Equal(a, b);
    }

    [Fact]
    public void Test2()
    {
        var mockLog = new Mock<ILogger<WeatherForecastController>>();
        WeatherForecastController controller = new WeatherForecastController(mockLog.Object);

        var result = controller.Get();
        Assert.NotNull(result);
        Assert.Equal(5, result.Count());

    }
}