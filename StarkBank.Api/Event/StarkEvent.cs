using System;
using System.Collections.Generic;
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

    [JsonPropertyName("isDelivered")]
    public bool IsDelivered { get; set; }

    [JsonPropertyName("subscription")]
    public string Subscription { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("log")]
    public StarkLog Log { get; set; }
}

public class StarkLog 
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("errors")]
    public List<object> Errors { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("transfer")]
    public StarkTransfer Transfer { get; set; }
}

public class StarkTransfer
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("bankCode")]
    public string BankCode { get; set; }

    [JsonPropertyName("branchCode")]
    public string BranchCode { get; set; }

    [JsonPropertyName("accountNumber")]
    public string AccountNumber { get; set; }

    [JsonPropertyName("taxId")]
    public string TaxId { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("updated")]
    public DateTime Updated { get; set; }

    [JsonPropertyName("transactionIds")]
    public List<string> TransactionIds { get; set; }

    [JsonPropertyName("fee")]
    public long Fee { get; set; }
}
