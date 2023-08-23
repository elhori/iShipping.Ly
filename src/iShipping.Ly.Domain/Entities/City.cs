using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class City
    {
        private City() { }

        public City(CityModel model)
        {
            Name = model.Name;
            AddressId = model.AddressId;
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public int AddressId { get; private set; }
        public Address Address { get; private set; } = null!;

        public int StateId { get; private set; }
        public State State { get; private set; } = null!;

        public void Update(CityModel model)
        {
            Name = model.Name;
            AddressId = model.AddressId;
        }
    }
}
