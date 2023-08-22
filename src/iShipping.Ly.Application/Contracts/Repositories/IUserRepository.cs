using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Identity;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<(Result, object)> AuthenticateAsync(LoginRequest model, CancellationToken cancellationToken);
        Task<Result> RegisterAsync(RegisterRequest model);
        Task<Result> RemoveUserAsync(string userId);
        Task<Response<GetUsersResponse>> GetUsersAsync(GetUsersRequest request, CancellationToken cancellationToken);
        Task<GetUsersResponse> GetUserAsync(string userId, CancellationToken cancellationToken);
        Task<Result> UpdateUserProfileAsync(UpdateUserProfileRequest request);
        Task<Result> ChangePasswordAsync(ChangePasswordRequest request);
        Task<Result> ResetPasswordAsync(ResetPasswordRequest request);
        Task<Response<GetUsersResponse>> SearchAsync(SearchUsersRequest request, CancellationToken cancellationToken);
        Task<Result> CreateAdminAsync(CreateAdminRequest request);
    }
}
