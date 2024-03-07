using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class AddressEntity
{
    [Key]
    [ForeignKey(nameof(UserEntity))]
    public string UserId { get; set; } = null!;

    public UserEntity User { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string? SteetName_2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    
}
