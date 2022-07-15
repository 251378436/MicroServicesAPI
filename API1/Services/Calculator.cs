namespace API1.Services
{
    public class Calculator : ICalculator
    {
        private static int Value = 0;
        public async Task<int> GetValue()
        {
            await Task.Delay(100);
            return Value;
        }

        public async Task IncreaseValue()
        {
            await Task.Delay(100);
            Value++;
        }
    }
}
