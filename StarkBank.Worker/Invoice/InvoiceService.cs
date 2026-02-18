using StarkBankTest.Worker.Invoice.Interface;
namespace StarkBankTest.Worker.Invoice;
public class InvoiceService : IInvoiceService
{
    public async Task<List<StarkBank.Invoice>> CreateInvoicesAsync()
    {
        var invoices = StarkBank.Invoice.Create(
            new List<StarkBank.Invoice>
            {
                new StarkBank.Invoice(
                    amount: 400000,
                    name: "Arya Stark",
                    taxID: "012.345.678-90",
                    due: DateTime.UtcNow.AddDays(10)
                ),
                
                new StarkBank.Invoice(
                    amount: 500000,
                    name: "Tony Stark",
                    taxID: "012.345.678-90",
                    due: DateTime.UtcNow.AddDays(10)
                ),
                
                new StarkBank.Invoice(
                    amount: 600000,
                    name: "Petter Stark",
                    taxID: "012.345.678-90",
                    due: DateTime.UtcNow.AddDays(10)
                )
            
            }
        );

        return invoices;
    }
}
