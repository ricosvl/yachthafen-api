using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using api.Models;
using System.Text;

namespace api.Services
{
	public class JwtServices
	{
		private readonly string _secretKey;
		private readonly string _issuer;


		public JwtServices(string secretKey, string issuer)
		{
			_secretKey = secretKey;
			_issuer = issuer;
		}

        public string generateToken(User user)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.firstname),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        // Add more claims as needed
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityTokenDescriptor
            {
                Issuer = _issuer,
                Audience = _issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = creds
            };

            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string generateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }




    }
}

