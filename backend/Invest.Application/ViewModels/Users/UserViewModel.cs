using Template.Application.ViewModels;

namespace Invest.Application.ViewModels.Users
{
    public class UserViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}