using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class SignInViewModel
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
