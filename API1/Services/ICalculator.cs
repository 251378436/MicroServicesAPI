namespace API1.Services
{
    public interface ICalculator
    {
        Task IncreaseValue();
        Task<int> GetValue();
    }
}
