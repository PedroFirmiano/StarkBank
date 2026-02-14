using StarkBank;

public interface ITransferService
{
    List<StarkBank.Transfer> CreateTransferFromInvoiceEvent(Event starkEvent);
}
