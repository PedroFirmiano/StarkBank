namespace StarkBankTest.Worker.Invoice.Interface
{
    public interface IInvoiceService
    {
        Task<List<StarkBank.Invoice>> CreateInvoicesAsync();
    }
}
