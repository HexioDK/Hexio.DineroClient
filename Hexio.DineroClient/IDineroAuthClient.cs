using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hexio.DineroClient.Models;
using RestEase;

namespace Hexio.DineroClient
{
    public interface IDineroAuthClient
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Post("/dineroapi/oauth/token")]
        Task<AuthResponse> Authenticate([Body] AuthRequest request);
    }
}