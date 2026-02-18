using StarkBank;
using System.Text.Json.Serialization;

public class StarkWebhookDto
{
    [JsonPropertyName("event")]
    public StarkEvent Event { get; set; }
}

public class StarkEvent
{
    [JsonPropertyName("Id")]
    public string Id { get; set; }


    [JsonPropertyName("subscription")]
    public string Subscription { get; set; }

    [JsonPropertyName("log")]
    public StarkLog Log { get; set; }
}

public class StarkLog
{
    [JsonPropertyName("invoice")]
    public StarkInvoice? Invoice { get; set; }
}

public class StarkInvoice
{
    public long Amount { get; set; }
}