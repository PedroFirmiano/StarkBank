using StarkBankTest.Domain.Request;

namespace StarkBankTest.Domain.Client.Interface
{
    public interface IStarkBankClient
    {
        Task SendInvoice(List<Invoice> invoices);
    }
}
