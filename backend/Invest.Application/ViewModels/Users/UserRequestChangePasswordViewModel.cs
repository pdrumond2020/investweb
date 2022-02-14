using System.ComponentModel.DataAnnotations;

namespace Invest.Application.ViewModels.Users
{
    public class UserRequestChangePasswordViewModel
    {
        [Required]
        public string Document { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }
    }
}