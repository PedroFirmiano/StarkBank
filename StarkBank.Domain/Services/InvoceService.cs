using StarkBankTest.Domain.Client.Interface;
using StarkBankTest.Domain.Request;

namespace StarkBankTest.Domain.Services;

public class InvoiceService
{
    public IStarkBankClient _client;

    public async Task SendInvoices()
    {
        List<Invoice> invoices =
    new List<Invoice> {
        new Invoice(
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
                    {"due", new DateTime(2021, 03, 12, 20, 30, 0)}
                }
            },
            rules: new List<Dictionary<string, object>>() {
                new Dictionary<string, object> {
                    {"key", "allowedTaxIds"},
                    {"value", new List<string> { "012.345.678-90", "45.059.493/0001-73" }}
                }
            },
            due: new DateTime(2021, 05, 12, 20, 30, 0),
            expiration: 123456789,
            fine: 2.5,
            interest: 1.3,
            name: "Arya Stark",
            tags: new List<string> { "New sword", "Invoice #1234" },
            taxID: "012.345.678-90"
        )
    };
        await _client.SendInvoice(invoices);
    }
}
