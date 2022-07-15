using API1.Services;

namespace API1
{
    public class TimedHostedService : BackgroundService
    {
        private readonly ILogger<TimedHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public TimedHostedService(ILogger<TimedHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"{nameof(TimedHostedService)} is running.");
            using PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
            while (!stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    await DoWorkAsync(stoppingToken);
                } catch (Exception ex)
                {
                    _logger.LogInformation("exception111111",ex);
                }
            }
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            //_logger.LogInformation($"************* Thread ID:{Thread.CurrentThread.ManagedThreadId} *****************");
            //_logger.LogInformation(
            //    "Timed Hosted Service is working. Count: {Count}", count);
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                ICalculator calculator =
                    scope.ServiceProvider.GetRequiredService<ICalculator>();

                await calculator.IncreaseValue();
                var sss = await calculator.GetValue();
                _logger.LogInformation($"********** The value is: {sss}. *******");
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"{nameof(TimedHostedService)} is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
