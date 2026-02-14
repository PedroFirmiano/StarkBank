using StarkBankTest.Worker.Invoice.Interface;

public class Worker : BackgroundService
{
    private readonly IInvoiceService _invoiceService;
    private readonly ILogger<Worker> _logger;

    public Worker(IInvoiceService invoiceService, ILogger<Worker> logger)
    {
        _invoiceService = invoiceService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var invoices = await _invoiceService.CreateInvoicesAsync();

            foreach (var invoice in invoices)
            {
                _logger.LogInformation("Invoice criada: {Id}", invoice.Id);
            }

            await Task.Delay(TimeSpan.FromHours(3), stoppingToken);
        }
    }
}
