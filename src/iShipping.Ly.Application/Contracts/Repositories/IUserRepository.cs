using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Identity;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<(Result, object)> AuthenticateAsync(LoginRequest model);
        Task<Result> RegisterAsync(RegisterRequest model);
        Task<Result> RemoveUserAsync(string userId);
        Task<Response<GetUsersResponse>> GetUsersAsync(GetUsersRequest request);
        Task<GetUsersResponse> GetUserAsync(string userId);
        Task<Result> UpdateUserProfileAsync(UpdateUserProfileRequest request);
        Task<Result> ChangePasswordAsync(ChangePasswordRequest request);
        Task<Response<GetUsersResponse>> SearchAsync(SearchUsersRequest request);
    }
}
