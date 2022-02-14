using Invest.Application.ViewModels.Users;
using System.Collections.Generic;

namespace Invest.Application.Interfaces
{
    public interface IUserService
    {
        bool Post(UserRequestCreateAccountViewModel user, string host);

        UserResponseAuthenticateViewModel Authenticate(UserRequestAuthenticateViewModel user);

        bool ForgotPassword(string document);

        bool ChangePassword(UserRequestChangePasswordViewModel user);

        bool ActivateUser(int userId);

        bool DeactivateUser(int userId);

        UserViewModel GetById(int userId);

        void ActivateByDocument(string document, string code);

        List<UserViewModel> Get();

        List<UserResponseListViewModel> GetAll();

        bool Put(UserUpdateAccount user);
    }
}