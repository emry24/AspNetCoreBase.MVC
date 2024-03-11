namespace Infrastructure.Models;

public class AddressModel
{
    //Ändrat här från int till string !!! och la till null!;
    public string UserId { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string? StreetName_2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
