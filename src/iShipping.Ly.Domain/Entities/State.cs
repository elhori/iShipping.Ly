using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class State
    {
        private State() { }

        public State(StateModel model)
        {
            Name = model.Name;
            CityId = model.CityId;
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public int CityId { get; private set; }
        public City City { get; private set; } = null!;

        public void Update(StateModel model)
        {
            Name = model.Name;
            CityId = model.CityId;
        }
    }
}
