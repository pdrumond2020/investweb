using Invest.CrossCutting.Auth.Interfaces;
using Invest.CrossCutting.Auth.ViewModels;
using Invest.CrossCutting.IoC.ExceptionHandler.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Security.Claims;

namespace Invest.CrossCutting.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetWindowsUser()
        {
            if (_httpContextAccessor?.HttpContext?.User == null)
                return null;

            return _httpContextAccessor?.HttpContext?.User.Identity.Name;
        }

        public ContextUserViewModel GetLoggedUser()
        {
            try
            {
                if (_httpContextAccessor?.HttpContext?.User == null)
                    return null;

                return new ContextUserViewModel
                {
                    Id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value,
                    Document = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    Name = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value,
                    IsAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated,
                };
            }
            catch (Exception)
            {
                throw new ApiException("Invalid Token", HttpStatusCode.Unauthorized);
            }
        }

        public ClaimsIdentity GetClaimsIdentityByContextUser(ContextUserViewModel user, string authenticationType = "Bearer")
        {
            return new ClaimsIdentity(new Claim[]
            {
                    //new Claim(ClaimTypes.PrimarySid, user.Id),
                    //new Claim(ClaimTypes.NameIdentifier, user.Document),
                    //new Claim(ClaimTypes.Name, user.Name)
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.PrimarySid, user.Document),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }, authenticationType);
        }
    }
}