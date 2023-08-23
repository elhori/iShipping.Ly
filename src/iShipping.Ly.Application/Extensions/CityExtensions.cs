﻿using iShipping.Ly.Application.Dtos.City;
using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Application.Extensions
{
    public static class CityExtensions
    {
        public static CityModel ToModel(this CreateCityRequest request)
        {
            return new CityModel(Id: 0, Name: request.Name, AddressId: request.AddressId);
        }

        public static CityModel ToModel(this UpdateCityRequest request)
        {
            return new CityModel(Id: request.Id, Name: request.Name, AddressId: request.AddressId);
        }

        public static GetCitiesResponse ToResponse(this City city)
        {
            return new GetCitiesResponse
            {
                Id = city.Id,
                Name = city.Name,
                AddressId = city.AddressId,
                StateId = city.StateId
            };
        }
    }
}