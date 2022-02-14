using Invest.CrossCutting.Auth.ViewModels;
using System.Security.Claims;

namespace Invest.CrossCutting.Auth.Interfaces
{
    public interface IAuthService
    {
        ContextUserViewModel GetLoggedUser();

        ClaimsIdentity GetClaimsIdentityByContextUser(ContextUserViewModel user, string authenticationType = "Bearer");
    }
}