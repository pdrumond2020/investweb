using Invest.CrossCutting.Auth.ViewModels;
using System.Security.Principal;

namespace Invest.CrossCutting.Auth.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(ContextUserViewModel user);
    }
}