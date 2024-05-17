namespace OrderIntegration.ACompany.Services.OrderManager.Worker.Workers
{
    internal class HourlyOrderWorker : BackgroundService
    {
        private readonly ILogger<HourlyOrderWorker> _logger;

        public HourlyOrderWorker(ILogger<HourlyOrderWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var nextHour = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0).AddHours(1);
                var delay = nextHour - now;
                _logger.LogInformation("HourlyOrderWorker uyku modunda: {time}. Bir sonraki çalışma: {nextHour}", DateTimeOffset.Now, nextHour);
                await Task.Delay(delay, stoppingToken);
                _logger.LogInformation("HourlyOrderWorker çalışmaya başladı: {time}", DateTimeOffset.Now);

                //To Do
                //Rest Request ve ile BŞirketine ilet ve kendi veritabanına tamamlandı - 2 olarak kaydet.

                _logger.LogInformation("Worker çalışmayı bitirdi: {time}", DateTimeOffset.Now);
            }
        }
    }
}
