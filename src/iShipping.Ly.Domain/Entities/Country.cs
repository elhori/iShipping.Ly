﻿using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class Country
    {
        private Country() { }

        public Country(CountryModel model)
        {
            Name = model.Name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        private readonly HashSet<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses;

        private readonly HashSet<State> _states = new();
        public IReadOnlyCollection<State> States => _states;

        public void Update(CountryModel model)
        {
            Name = model.Name;
        }
    }
}
