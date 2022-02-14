using Template.Application.ViewModels;

namespace Invest.Application.ViewModels.Users
{
    public class UserResponseAuthenticateViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Profile { get; set; }
        public string Token { get; set; }
    }
}