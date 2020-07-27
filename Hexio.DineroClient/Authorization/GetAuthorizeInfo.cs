using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;

namespace Hexio.DineroClient.Authorization
{
    public interface IGetAuthorizeInfo
    {
        Task<(string AuthUrl, string CodeVerifier, string State)> Execute();
    }

    public class GetAuthorizeInfo : IGetAuthorizeInfo
    {
        private readonly IGetEndpoints _getEndpoints;
        private readonly VismaConnectSettings _settings;

        public GetAuthorizeInfo(
            IGetEndpoints getEndpoints,
            VismaConnectSettings settings)
        {
            _getEndpoints = getEndpoints;
            _settings = settings;
        }

        public async Task<(string AuthUrl, string CodeVerifier, string State)> Execute()
        {
            var authEndpoint = (await _getEndpoints.Execute()).AuthorizeEndpoint;

            var requestUrl = new RequestUrl(authEndpoint);

            var codeVerifier = CryptoRandom.CreateUniqueId();
            var codeChallenge = CreateCodeChallenge(codeVerifier);
            var state = CryptoRandom.CreateUniqueId();

            var authUrl = requestUrl.CreateAuthorizeUrl(
                clientId: _settings.ClientId,
                responseType: "code",
                nonce: CryptoRandom.CreateUniqueId(),
                state: state,
                codeChallenge: codeChallenge,
                codeChallengeMethod: "S256",
                scope: "dineropublicapi:read dineropublicapi:write offline_access",
                redirectUri: _settings.ReturnUrl
            );

            return (authUrl, codeVerifier, state);
        }

        private string CreateCodeChallenge(string codeVerifier)
        {
            var sha256 = SHA256.Create();

            var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));

            return Base64Url.Encode(challengeBytes);
        }
    }
}