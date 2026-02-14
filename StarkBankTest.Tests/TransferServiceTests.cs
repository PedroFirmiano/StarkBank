public class TransferServiceTests
{
    [Fact]
    public void Should_Not_Create_Transfer_When_Subscription_Is_Not_Invoice()
    {
        var service = new TransferService();

        var dto = new StarkWebhookDto
        {
            Event = new StarkEvent
            {
                Subscription = "transfer"
            }
        };

        var result = service.CreateTransferFromInvoiceEvent(dto);

        Assert.Empty(result);
    }
}