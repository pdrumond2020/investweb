using AutoMapper;
using Invest.Application.Services;
using Invest.Application.ViewModels.Users;
using Invest.CrossCutting.Auth.ViewModels;
using Invest.Domain.Entities;

namespace Invest.CrossCutting.IoC.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMapperModels();
        }

        private void CreateMapperModels()
        {
            #region "ViewModel To Domain"

            CreateMap<UserRequestCreateAccountViewModel, User>();

            #endregion "ViewModel To Domain"

            #region "Domain to ViewModel"

            CreateMap<User, ContextUserViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserResponseListViewModel>().ReverseMap();
            CreateMap<User, UserResponseAuthenticateViewModel>();

            #endregion "Domain to ViewModel"
        }
    }
}