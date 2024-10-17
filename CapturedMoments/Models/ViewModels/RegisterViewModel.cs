using System.ComponentModel.DataAnnotations;

namespace CapturedMoments.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "PASSWORD AND CONFIEM NOT MATCH")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
    }

}
