using Newtonsoft.Json;

namespace Hexio.DineroClient.Auth
{
    public class AuthResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}