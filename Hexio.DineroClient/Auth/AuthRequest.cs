namespace Hexio.DineroClient.Auth
{
    public class AuthRequest
    {
        public string grant_type { get; set; } = "password";
        public string scope { get; set; } = "read write";
        public string username { get; set; }
        public string password { get; set; }

        public AuthRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}