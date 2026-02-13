namespace StarkBankTest.Domain.Request;

public class SendInvoiceRequest
{
    public List<Invoice> Invoices { get; set; } = [];
}
