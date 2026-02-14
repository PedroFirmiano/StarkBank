using StarkBank;

public class TransferService : ITransferService
{
    public List<StarkBank.Transfer> CreateTransferFromInvoiceEvent(Event starkEvent)
    {
        if (starkEvent.Subscription != "invoice")
        {
            StarkBank.Invoice.Log log = starkEvent.Log as StarkBank.Invoice.Log;

            var transfers = StarkBank.Transfer.Create(
                new List<StarkBank.Transfer>
                {
                new StarkBank.Transfer(
                    amount: log.Invoice.Amount,
                    bankCode: "20018183",
                    branchCode: "0001",
                    accountNumber: "6341320293482496",
                    taxID: "20.018.183/0001-80",
                    name: "Stark Bank S.A.",
                    externalID: Guid.NewGuid().ToString()
                )
                });

            return transfers;
        }
        return new List<Transfer>();
    }
}
