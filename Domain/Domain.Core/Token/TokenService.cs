using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Core.Entities;
using Domain.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Core.Token;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var secretKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key:TokenKey"] ?? string.Empty));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = "eu_mesmo",
            Audience = "auth_back",
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var userToken = tokenHandler.WriteToken(token);

        return userToken;
    }
    
    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claimIdentity = new ClaimsIdentity();

        var roles = new[]
        {
            "admin"
        };
        
        claimIdentity.AddClaims(new []
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        });

        foreach (var role in roles) claimIdentity.AddClaim(new Claim(ClaimTypes.Role, role));

        return claimIdentity;
    }
}