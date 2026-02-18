using StarkBank;

public class TransferService : ITransferService
{
    public List<Transfer> CreateTransferFromInvoiceEvent(StarkWebhookDto starkEvent)
    {
        if (starkEvent.Event.Subscription == "invoice")
        {
           
            var transfers = StarkBank.Transfer.Create(
                new List<StarkBank.Transfer>
                {
                new StarkBank.Transfer(
                    amount: starkEvent.Event.Log.Invoice.Amount,
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
