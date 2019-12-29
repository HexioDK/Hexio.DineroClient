using RestEase;

namespace Hexio.DineroClient.Module
{
    public static class DineroClientFactory
    {
        public static IDineroClient Execute(DineroApiSettings settings)
        {
            var client = RestClient.For<IDineroClient>(settings.ApiUrl);

            return client;
        }
    }
}