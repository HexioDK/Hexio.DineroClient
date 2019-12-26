using Newtonsoft.Json;

namespace Hexio.DineroClient.Models
{
    public class AuthResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}