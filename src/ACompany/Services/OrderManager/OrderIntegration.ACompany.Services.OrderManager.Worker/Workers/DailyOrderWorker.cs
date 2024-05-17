using MediatR;
using OrderIntegration.ACompany.Services.OrderManager.Application.Commands;
using OrderIntegration.ACompany.Services.OrderManager.Application.Queries;
using OrderReference;
using System.ServiceModel;

namespace OrderIntegration.ACompany.Services.OrderManager.Worker.Workers
{
    public class DailyOrderWorker : BackgroundService
    {
        private readonly ILogger<DailyOrderWorker> _logger;
        private readonly IMediator _mediator;

        public DailyOrderWorker(ILogger<DailyOrderWorker> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            GetOrders();//TEST
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var nextRun = now.Date.AddDays(1).AddMinutes(1); // Bir sonraki gün 00:01 de çalışsın
                var timeToWait = nextRun - now;

                _logger.LogInformation("DailyOrderWorker uyku modunda. Bir sonraki çalışma: {NextRun}", nextRun);
                await Task.Delay(timeToWait, stoppingToken);
                _logger.LogInformation("DailyOrderWorker çalışmaya başladı: {Now}", DateTime.Now);
                await GetOrders();
            }
        }

        protected async Task GetOrders()
        {
            var client = new OrderSoapServiceClient();

            try
            {
                var response = await client.GetOrdersByDateAsync(DateTime.Now.AddDays(-1));
                //To Do Auto mapper uygulanacak
                var newOrders = response.Select(s => new Application.Dtos.OrderDto
                {
                    ReceiverAddress = "TEST",
                    ReceiverName = "TEST",
                    CreatedDate = s.CreatedDate,
                    IntegrationId = s.Id,
                    OrderStatusId = 0,
                    OrderItems = s.OrderItems.Select(s => new Application.Dtos.OrderItemDto
                    {
                        ItemName = s.ItemName,
                        Quantity = s.Quantity,
                    }).ToList(),
                }).ToList();

                await _mediator.Send(new AddOrdersListCommand { Orders = newOrders });
            }
            catch (Exception ex)
            {
                //To Do
                //Hata işleme
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
