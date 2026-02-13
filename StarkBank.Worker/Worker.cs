namespace StarkBankTest.Worker;

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
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);



            List<StarkBank.Invoice> invoices = StarkBank.Invoice.Create(
                new List<StarkBank.Invoice> {
                new StarkBank.Invoice(
                amount: 400000,
                descriptions: new List<Dictionary<string, object>>() {
                    new Dictionary<string, object> {
                        {"key", "Arya"},
                        {"value", "Not today"}
                    }
                },
                discounts: new List<Dictionary<string, object>>() {
                    new Dictionary<string, object> {
                        {"percentage", 10},
                        {"due", new DateTime(2026, 03, 12, 20, 30, 0)}
                    }
                },
                due: new DateTime(2026, 05, 12, 20, 30, 0),
                expiration: 123456789,
                fine: 2.5,
                interest: 1.3,
                name: "Arya Stark",
                tags: new List<string> { "New sword", "Invoice #1234" },
                taxID: "012.345.678-90"
            ),
                new StarkBank.Invoice(
                amount: 400000,
                descriptions: new List<Dictionary<string, object>>() {
                    new Dictionary<string, object> {
                        {"key", "Pedro"},
                        {"value", "Not today"}
                    }
                },
                discounts: new List<Dictionary<string, object>>() {
                    new Dictionary<string, object> {
                        {"percentage", 10},
                        {"due", new DateTime(2026, 03, 12, 20, 30, 0)}
                    }
                },
                due: new DateTime(2026, 05, 12, 20, 30, 0),
                expiration: 123456789,
                fine: 2.5,
                interest: 1.3,
                name: "Pedro Stark",
                tags: new List<string> { "New sword", "Invoice #1234" },
                taxID: "012.345.678-90"
            ),
                new StarkBank.Invoice(
                amount: 400000,
                descriptions: new List<Dictionary<string, object>>() {
                    new Dictionary<string, object> {
                        {"key", "Tony"},
                        {"value", "Not today"}
                    }
                },
                discounts: new List<Dictionary<string, object>>() {
                    new Dictionary<string, object> {
                        {"percentage", 10},
                        {"due", new DateTime(2026, 03, 12, 20, 30, 0)}
                    }
                },
                due: new DateTime(2026, 05, 12, 20, 30, 0),
                expiration: 123456789,
                fine: 2.5,
                interest: 1.3,
                name: "Tony Stark",
                tags: new List<string> { "New sword", "Invoice #1234" },
                taxID: "012.345.678-90"
            )
                }

            );

            foreach (StarkBank.Invoice invoice in invoices)
            {
                Console.WriteLine(invoice);
            }


            await Task.Delay(TimeSpan.FromHours(3), stoppingToken);
        }
    }
}
