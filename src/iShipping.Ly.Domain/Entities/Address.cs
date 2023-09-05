using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class Address
    {
        private Address() { }

        public Address(AddressModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            AddressLineOne = model.AddressLineOne;
            AddressLineTwo = model.AddressLineTwo;
            ZipCode = model.ZipCode;
            Phone = model.Phone;
            CityId = model.CityId;
            CountryId = model.CountryId;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public string AddressLineOne { get; private set; } = string.Empty;

        public string AddressLineTwo { get; private set; } = string.Empty;

        public string ZipCode { get; private set; } = string.Empty;

        public string Phone { get; private set; } = string.Empty;

        public int CityId { get; private set; }
        public City City { get; private set; } = null!;

        public int CountryId { get; private set; }
        public Country Country { get; private set; } = null!;

        public void Update(AddressModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            AddressLineOne = model.AddressLineOne;
            AddressLineTwo = model.AddressLineTwo;
            ZipCode = model.ZipCode;
            Phone = model.Phone;
            CityId = model.CityId != 0 ? model.CityId : CityId;
            CountryId = model.CountryId != 0 ? model.CountryId : CountryId;
        }
    }
}
