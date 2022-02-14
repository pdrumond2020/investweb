using Invest.CrossCutting.Auth.Interfaces;
using Invest.CrossCutting.Auth.Models;
using Invest.CrossCutting.Auth.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Invest.CrossCutting.Auth.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _serviceAuth;
        private readonly TokenConfigurationsViewModel _tokenConfigurations;

        public TokenService(IConfiguration configuration, IAuthService serviceAuth)
        {
            _configuration = configuration;
            _serviceAuth = serviceAuth;
            _tokenConfigurations = new TokenConfigurationsViewModel();
        }

        public string GenerateToken(ContextUserViewModel user)
        {
            JwtSecurityTokenHandler _tokenHandler = new();
            byte[] _key = Encoding.ASCII.GetBytes(Settings.Secret);

            SecurityTokenDescriptor _tokenDescriptor = new()
            {
                Subject = _serviceAuth.GetClaimsIdentityByContextUser(user),
                Expires = DateTime.UtcNow.AddHours(3),
                NotBefore = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken _generatedToken = _tokenHandler.CreateToken(_tokenDescriptor);

            return _tokenHandler.WriteToken(_generatedToken);
        }

        public static string GetValueFromClaim(IIdentity identity, string field)
        {
            var claims = identity as ClaimsIdentity;

            return claims.FindFirst(field).Value;
        }
    }
}