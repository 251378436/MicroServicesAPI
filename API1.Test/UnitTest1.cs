using Xunit;

namespace API1.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var a = 123;
            var b = 123;
            Assert.Equal(a, b);
        }
    }
}