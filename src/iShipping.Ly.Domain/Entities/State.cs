using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class State
    {
        private State() { }

        public State(StateModel model)
        {
            Name = model.Name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public int CountryId { get; private set; }
        public Country Country { get; private set; } = null!;

        private readonly HashSet<City> _cities = new();
        public IReadOnlyCollection<City> Cities => _cities;

        public void Update(StateModel model)
        {
            Name = model.Name;
        }
    }
}
