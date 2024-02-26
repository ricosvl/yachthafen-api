using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    internal class JwtSecurityTokenDescriptor : SecurityTokenDescriptor
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public ClaimsIdentity Subject { get; set; }
        public DateTime Expires { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}