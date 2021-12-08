using System.ComponentModel.DataAnnotations;

namespace Challenge.ViewModels.Auth.Login
{
    public class LoginRequestViewModel
    {
        [Required]
        [MinLength(6)]

        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
