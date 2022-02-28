using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.DTOs
{
    public class UserLoginDto
    {
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Mail is not in correct format.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters.")]
        public string Password { get; set; }
    }
}
