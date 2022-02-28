using Microsoft.AspNetCore.Identity;
using System;

namespace UserManagement.Domain.Models
{
    public class AppUser : IdentityUser<int>
    {
        public int Gender { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
