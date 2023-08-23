namespace iShipping.Ly.Domain.Models
{
    public record AddressModel(
        int Id,
        string FirstName,
        string LastName,
        string AddressLineOne,
        string AddressLineTwo,
        string ZipCode,
        string Phone,
        int CityId,
        int CountryId);
}
