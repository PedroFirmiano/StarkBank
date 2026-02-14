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
            Assert.False(string.IsNullOrEmpty(invoice.ID));
        });
    }

    [Fact]
    public async Task Should_Create_Multiple_Invoices()
    {
        var service = new InvoiceService();

        var invoices = await service.CreateInvoicesAsync();

        Assert.NotNull(invoices);
        Assert.True(invoices.Count > 0);

        foreach (var invoice in invoices)
        {
            Assert.False(string.IsNullOrEmpty(invoice.ID));
        }
    }
}
