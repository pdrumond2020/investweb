using System.ComponentModel.DataAnnotations;

namespace Invest.Application.ViewModels.Users
{
    public class UserRequestAuthenticateViewModel
    {
        [Required]
        public string Document { get; set; }

        [Required]
        public string Password { get; set; }
    }
}