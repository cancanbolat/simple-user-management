using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.DTOs
{
    public class PasswordChangeDto
    {
        [Required]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters.")]
        public string PasswordOld { get; set; }

        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters.")]
        public string PasswordNew { get; set; }

        [Required]
        [Display(Name = "Password Confirm")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters.")]
        [Compare("PasswordNew", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
