using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Address;
using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class AddressRepository : AsyncRepository<Address>, IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Response<GetAddressesResponse>> GetResponseAsync(GetAddressesRequest request, CancellationToken cancellationToken = default)
        {
            var data = _context.Addresses.AsNoTracking();

            var skip = request.PageSize * (request.CurrentPage - 1);

            var totalResults = await data.CountAsync();

            var results = await data
                .OrderBy(i => i.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(i => new GetAddressesResponse
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    AddressLineOne = i.AddressLineOne,
                    AddressLineTwo = i.AddressLineTwo,
                    Phone = i.Phone,
                    ZipCode = i.ZipCode,
                    CityId = i.CityId,
                    CityName = i.City.Name,
                    StateId = i.City.State.Id,
                    StateName = i.City.State.Name,

                }).ToListAsync(cancellationToken);

            return new Response<GetAddressesResponse>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalResults = totalResults,
                Results = results
            };
        }
    }
}
