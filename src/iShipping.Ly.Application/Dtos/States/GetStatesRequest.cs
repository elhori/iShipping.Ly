using MediatR;

namespace iShipping.Ly.Application.Dtos.States
{
    public record GetStatesRequest(int CurrentPage = 1, int PageSize = 25) : IRequest<Response<GetStatesResponse>>;

    public class GetStatesResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
    }
}
