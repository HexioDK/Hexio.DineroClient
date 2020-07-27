namespace Hexio.DineroClient.Authorization
{
    public class VismaConnectSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ReturnUrl { get; set; }
        public string DiscoveryEndpoint { get; set; } = "https://connect.visma.com/.well-known/openid-configuration";
    }
}