using System.Threading.Tasks;
using IdentityModel.Client;

namespace Hexio.DineroClient.Authorization
{
    public interface IGetEndpoints
    {
        Task<DiscoveryDocumentResponse> Execute();
    }

    public class GetEndpoints : IGetEndpoints
    {
        private readonly VismaConnectSettings _vismaConnectSettings;

        public GetEndpoints(VismaConnectSettings vismaConnectSettings)
        {
            _vismaConnectSettings = vismaConnectSettings;
        }

        public async Task<DiscoveryDocumentResponse> Execute()
        {
            return await new DiscoveryCache(_vismaConnectSettings.DiscoveryEndpoint, new DiscoveryPolicy
            {
                ValidateIssuerName = false,
                ValidateEndpoints = false,
            }).GetAsync();
        }
    }
}