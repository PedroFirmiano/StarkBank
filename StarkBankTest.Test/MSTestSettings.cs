public class InvoiceIntegrationTests
{
    [Fact]
    public async Task Should_Create_Invoice_On_StarkBank()
    {
        // Arrange
        var service = new InvoiceService();

        // Act
        var result = await service.CreateInvoicesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.All(result, invoice =>
        {
            Assert.False(string.IsNullOrEmpty(invoice.Id));
        });
    }
}
