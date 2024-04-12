using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        public bool IsExternalAccount { get; set; } = false;

        public AddressEntity Address { get; set; } = null!;
    }
}
