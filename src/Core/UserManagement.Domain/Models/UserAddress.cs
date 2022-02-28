namespace UserManagement.Domain.Models
{
    public class UserAddress : BaseModel
    {
        public int UserId { get; set; }
        public AppUser User { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
