using StarkBank;

public interface ITransferService
{
    List<StarkBank.Transfer> CreateTransferFromInvoiceEvent(StarkWebhookDto starkEvent);
}
