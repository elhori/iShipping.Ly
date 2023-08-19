using iShipping.Ly.Application.Dtos.Identity;
using Microsoft.AspNetCore.Identity;

namespace iShipping.Ly.Infra.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
