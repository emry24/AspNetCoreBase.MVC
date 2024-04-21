namespace Infrastructure.Models;

public class AddressModel
{
    public string UserId { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string? StreetName_2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
