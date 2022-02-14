using Template.Application.ViewModels;

namespace Invest.Application.ViewModels.Users
{
    public class UserResponseListViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public bool IsActive { get; set; }
        public bool IsAuthorised { get; set; }
        public string Code { get; set; }
    }
}