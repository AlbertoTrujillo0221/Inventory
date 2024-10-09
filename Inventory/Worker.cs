using Domain.Interfaces.Application;

namespace Inventory
{
    public class Worker(IProductService productService,
                        ILogger<Worker> logger) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                var products = await productService.GetAll(stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
