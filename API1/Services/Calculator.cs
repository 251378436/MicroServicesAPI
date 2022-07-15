namespace API1.Services
{
    public class Calculator : ICalculator, IDisposable
    {
        private static int Value = 0;

        public void Dispose()
        {
            Console.WriteLine("*********** Disposed ************");
        }

        public async Task<int> GetValue()
        {
            await Task.Delay(100);

            (int Quotient, int Remainder) = Math.DivRem(Value, 5);

            if (Remainder == 0)
                throw new Exception("the value is not what needed");
            return Value;
        }

        public async Task IncreaseValue()
        {
            await Task.Delay(100);
            Value++;
        }
    }
}
