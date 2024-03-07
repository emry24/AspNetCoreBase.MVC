using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Entities
{
    public class UserEntity : IdentityUser
    {
        [ProtectedPersonalData]
        [Required]
        public string FirstName { get; set; } = null!;

        [ProtectedPersonalData]
        [Required]
        public string LastName { get; set; } = null!;

        public string? Biography { get; set; }
        public string? ProfileImageUrl { get; set; }

        public AddressEntity Address { get; set; } = null!;
    }
}
