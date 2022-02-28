using System;

namespace UserManagement.Domain.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
    }
}
