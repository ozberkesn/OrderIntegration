using OrderReference;
using System.ServiceModel;

namespace OrderIntegration.ACompany.Services.OrderManager.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        protected async void GetOrders()
        {
            var client = new OrderSoapServiceClient();

            try
            {
                var response = await client.GetOrdersByDateAsync(DateTime.Now);
            }
            catch (FaultException ex)
            {
                // Hata i�leme
            }
            finally
            {
                if (client.State == CommunicationState.Faulted)
                    client.Abort();
                else
                    client.Close();
            }
        }
    }
}
