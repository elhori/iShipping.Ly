using MediatR;

namespace iShipping.Ly.Application.Dtos.Country
{
    public record GetCountriesRequest(int CurrentPage = 1, int PageSize = 25) : IRequest<Response<GetCountriesResponse>>;

    public class GetCountriesResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
