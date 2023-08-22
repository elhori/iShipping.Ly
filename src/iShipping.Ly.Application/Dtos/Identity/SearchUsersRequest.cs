using MediatR;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public record SearchUsersRequest(string Query, int CurrentPage = 1, int PageSize = 25)
        : IRequest<Response<GetUsersResponse>>;
}
