using System.ComponentModel.DataAnnotations;

namespace AccountService.Models.ViewModels
{
    public class AccountLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public AccountLoginViewModel()
        {

        }
    }
}