using System.Net.Http.Headers;
using Hexio.DineroClient.Module;
using RestEase;

namespace Hexio.DineroClient.Auth
{
    public static class DineroAuthClientFactory
    {
        public static IDineroAuthClient Execute(DineroApiSettings settings)
        {
            var client = RestClient.For<IDineroAuthClient>(settings.AuthUrl);

            var byteArray = System.Text.Encoding.UTF8.GetBytes($"{settings.ClientId}:{settings.ClientSecret}");
            
            client.Authorization = new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(byteArray)); System.Convert.ToBase64String(byteArray);

            return client;
        }
    }
}