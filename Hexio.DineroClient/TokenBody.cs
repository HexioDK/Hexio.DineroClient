using Newtonsoft.Json;

namespace Hexio.DineroClient
{
    public class TokenBody
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; } = "client_credentials";
        
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
        
        [JsonProperty("tenant_id")]
        public string TenantId { get; set; }
    }
}