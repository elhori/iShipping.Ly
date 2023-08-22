using iShipping.Ly.Application.Constants;
using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Identity;
using iShipping.Ly.Application.Resources;
using iShipping.Ly.Domain.Exceptions;
using iShipping.Ly.Infra.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class UserRepository : AsyncRepository<AppUser>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly DataContext _context;

        public UserRepository(UserManager<AppUser> userManager, IConfiguration config, DataContext context) : base(context)
        {
            _config = config;
            _userManager = userManager;
            _context = context;
        }

        public async Task<(Result, object)> AuthenticateAsync(LoginRequest model, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.Users.FirstAsync(u => u.PhoneNumber == model.PhoneNumber, cancellationToken);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                return (IdentityResult.Success.ToApplicationResult(), new
                {
                    id = $"{user.Id}",
                    username = $"{user.UserName}",
                    fullname = $"{user.FirstName} {user.LastName}",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return (IdentityResult.Failed().ToApplicationResult(), null!);
        }

        public async Task<Result> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user is null)
            {
                return IdentityResult.Failed().ToApplicationResult();
            }

            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                //TODO: send errors to client
                return IdentityResult.Failed().ToApplicationResult();
            }

            return IdentityResult.Success.ToApplicationResult();
        }

        public async Task<Result> CreateAdminAsync(CreateAdminRequest request)
        {
            var userExists = await _userManager.FindByNameAsync(request.UserName);

            if (userExists != null)
                throw new AppException(ExceptionStatusCode.AlreadyExists, ExceptionMessages.UserAlreadyExist);

            AppUser user = new AppUser(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return IdentityResult.Failed().ToApplicationResult();

            var roleResult = await _userManager.AddToRoleAsync(user, request.Role.ToString());

            if (!roleResult.Succeeded)
                return IdentityResult.Failed().ToApplicationResult();

            return IdentityResult.Success.ToApplicationResult();
        }

        public async Task<GetUsersResponse> GetUserAsync(string userId, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            if (user == null)
            {
                throw new AppException(ExceptionStatusCode.NotFound, ExceptionMessages.UserNotFound);
            }

            var roles = await _userManager.GetRolesAsync(user);

            var response = new GetUsersResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                IdentificationCardNumber = user.IdentificationCardNumber!
            };

            return response;
        }

        public async Task<Response<GetUsersResponse>> GetUsersAsync(GetUsersRequest request, CancellationToken cancellationToken = default)
        {
            if (await _userManager.Users.AsNoTracking().CountAsync(cancellationToken) == 0)
            {
                throw new AppException(ExceptionStatusCode.NotFound, ExceptionMessages.EmptyUsersResponse);
            }

            var skip = request.PageSize * (request.CurrentPage - 1);

            var data = await _userManager.Users
                .OrderBy(i => i.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(i => new GetUsersResponse
                {
                    Id = i.Id,
                    PhoneNumber = i.PhoneNumber,
                    UserName = i.UserName,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    IdentificationCardNumber = i.IdentificationCardNumber!
                }).ToListAsync(cancellationToken);

            return new Response<GetUsersResponse>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalResults = data.Count,
                Results = data
            };
        }

        public async Task<Result> RegisterAsync(RegisterRequest model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);

            if (userExists != null)
                throw new AppException(ExceptionStatusCode.AlreadyExists, ExceptionMessages.UserAlreadyExist);

            AppUser user = new AppUser(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return IdentityResult.Failed().ToApplicationResult();

            var roleResult = await _userManager.AddToRoleAsync(user, model.Role.ToString());

            if (!roleResult.Succeeded)
                return IdentityResult.Failed().ToApplicationResult();

            return IdentityResult.Success.ToApplicationResult();
        }

        public async Task<Result> RemoveUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new AppException(ExceptionStatusCode.NotFound, ExceptionMessages.UserNotFound);

            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.Contains(nameof(Roles.SuperAdmin)))
            {
                return IdentityResult.Failed().ToApplicationResult();
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return IdentityResult.Failed().ToApplicationResult();

            return IdentityResult.Success.ToApplicationResult();
        }

        public async Task<Result> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user is null)
            {
                return IdentityResult.Failed().ToApplicationResult();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                //TODO: send errors to client
                return IdentityResult.Failed().ToApplicationResult();
            }

            return IdentityResult.Success.ToApplicationResult();
        }

        public async Task<Response<GetUsersResponse>> SearchAsync(SearchUsersRequest request, CancellationToken cancellationToken = default)
        {
            var upperQuery = request.Query.ToUpper();

            var skip = request.PageSize * (request.CurrentPage - 1);

            var data = await _userManager.Users
                .Where(u => EF.Functions.Like(u.Email.ToUpper(), $"%{upperQuery}%") ||
                            EF.Functions.Like(u.UserName.ToUpper(), $"%{upperQuery}%") ||
                            EF.Functions.Like(u.PhoneNumber.ToUpper(), $"%{upperQuery}%") ||
                            EF.Functions.Like((u.FirstName + " " + u.LastName).ToUpper(), $"%{upperQuery}%"))
                .OrderBy(i => i.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(r => new GetUsersResponse
                {
                    Id = r.Id,
                    UserName = r.UserName,
                    PhoneNumber = r.PhoneNumber,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    IdentificationCardNumber = r.IdentificationCardNumber!
                }).ToListAsync(cancellationToken);

            return new Response<GetUsersResponse>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalResults = data.Count,
                Results = data
            };
        }

        public async Task<Result> UpdateUserProfileAsync(UpdateUserProfileRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id)
                ?? throw new AppException(ExceptionStatusCode.NotFound, ExceptionMessages.UserNotFound);

            user.UpdateProfile(request);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return IdentityResult.Failed().ToApplicationResult();

            return IdentityResult.Success.ToApplicationResult();
        }
    }
}
