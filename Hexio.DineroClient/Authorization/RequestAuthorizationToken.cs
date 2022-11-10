using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Hexio.DineroClient.Authorization
{
    public interface IRequestAuthorizationToken
    {
        Task<IdentityModel.Client.TokenResponse> Execute(string code, string codeVerifier);
        Task<IdentityModel.Client.TokenResponse> Execute(string refreshToken);
    }

    public class RequestAuthorizationToken : IRequestAuthorizationToken
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGetEndpoints _getEndpoints;
        private readonly VismaConnectSettings _settings;

        public RequestAuthorizationToken(
            VismaConnectSettings settings,
            IGetEndpoints getEndpoints,
            IHttpClientFactory httpClientFactory)
        {
            _getEndpoints = getEndpoints;
            _httpClientFactory = httpClientFactory;
            _settings = settings;
        }

        public async Task<IdentityModel.Client.TokenResponse> Execute(string code, string codeVerifier)
        {
            var tokenEndpoint = (await _getEndpoints.Execute()).TokenEndpoint;

            return await _httpClientFactory.CreateClient().RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = tokenEndpoint,
                ClientId = _settings.ClientId,
                ClientSecret = _settings.ClientSecret,
                Code = code,
                RedirectUri = _settings.ReturnUrl,
                CodeVerifier = codeVerifier
            });
        }
        
        public async Task<IdentityModel.Client.TokenResponse> Execute(string refreshToken)
        {
            var tokenEndpoint = (await _getEndpoints.Execute()).TokenEndpoint;

            return await _httpClientFactory.CreateClient().RequestRefreshTokenAsync(new RefreshTokenRequest()
            {
                Address = tokenEndpoint,
                ClientId = _settings.ClientId,
                ClientSecret = _settings.ClientSecret,
                RefreshToken = refreshToken
            });
        }
    }
}