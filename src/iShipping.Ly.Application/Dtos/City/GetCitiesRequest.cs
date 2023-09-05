using MediatR;

namespace iShipping.Ly.Application.Dtos.City
{
    public record GetCitiesRequest(int CurrentPage = 1, int PageSize = 25) : IRequest<Response<GetCitiesResponse>>;

    public class GetCitiesResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
    }
}
