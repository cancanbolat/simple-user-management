using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Models;

namespace UserManagement.Domain.DTOs
{
    public class RoleDto : BaseModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
