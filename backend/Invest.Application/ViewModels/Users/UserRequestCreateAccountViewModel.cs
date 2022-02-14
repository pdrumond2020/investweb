using System.ComponentModel.DataAnnotations;

namespace Invest.Application.ViewModels.Users
{
    public class UserRequestCreateAccountViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Document { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }
    }
}