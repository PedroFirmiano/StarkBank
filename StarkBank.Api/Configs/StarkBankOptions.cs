namespace StarkBankTest.Api.Configs;

public class StarkBankOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public string BearerToken { get; set; } = string.Empty;
    public string Enviroment { get; set; }
    public string ProjectId { get; set; }
    public string PrivateKey { get; set; }
}