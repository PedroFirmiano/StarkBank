using StarkBankTest.Domain.Services.Interfaces;

namespace StarkBankTest.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IInvoiceService _invoiceService;

        public Worker(ILogger<Worker> logger, IInvoiceService service)
        {
            _logger = logger;
            _invoiceService = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await _invoiceService.SendInvoices();

                await Task.Delay(TimeSpan.FromHours(3), stoppingToken);
            }
        }
    }
}
