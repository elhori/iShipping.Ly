using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class City
    {
        private City() { }

        public City(CityModel model)
        {
            Name = model.Name;
            StateId = model.StateId;
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public int? StateId { get; private set; }
        public State State { get; private set; } = null!;

        private readonly HashSet<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses;

        public void Update(CityModel model)
        {
            Name = model.Name;
            StateId = model.StateId! != 0 ? model.StateId : StateId;
        }
    }
}
