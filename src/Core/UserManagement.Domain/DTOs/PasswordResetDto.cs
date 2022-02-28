using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.DTOs
{
    public class PasswordResetDto
    {
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Mail is not in correct format.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters.")]
        public string PasswordNew { get; set; }
    }
}
