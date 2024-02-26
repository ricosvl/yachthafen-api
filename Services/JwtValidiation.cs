using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

public class JwtValidation
{
    private readonly string _secretKey;
    private readonly string _issuer;

    public JwtValidation(string secretKey, string issuer)
    {
        _secretKey = secretKey;
        _issuer = issuer;
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = GetValidationParameters();

        try
        {
            SecurityToken validatedToken;
            tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return true;
        }
        catch (SecurityTokenException)
        {
            return false;
        }
    }

    private TokenValidationParameters GetValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _issuer,
            ValidAudience = _issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(_secretKey))
        };
    }
}
