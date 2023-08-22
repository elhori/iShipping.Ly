using iShipping.Ly.Application.Dtos.Identity;
using Microsoft.AspNetCore.Identity;

namespace iShipping.Ly.Infra.Identity
{
    public class AppUser : IdentityUser
    {
        private AppUser() { }

        public AppUser(RegisterRequest request)
        {
            UserName = request.UserName;
            Email = request.Email;
            PhoneNumber = request.PhoneNumber;
            FirstName = request.FirstName;
            LastName = request.LastName;
            IdentificationCardNumber = request.IdentificationCardNumber!;
            EmailConfirmed = true;
            SecurityStamp = Guid.NewGuid().ToString();
        }

        public AppUser(CreateAdminRequest request)
        {
            UserName = request.UserName;
            Email = request.Email;
            PhoneNumber = request.PhoneNumber;
            FirstName = request.FirstName;
            LastName = request.LastName;
            IdentificationCardNumber = request.IdentificationCardNumber!;
            EmailConfirmed = true;
            SecurityStamp = Guid.NewGuid().ToString();
        }

        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public string? IdentificationCardNumber { get; private set; } = string.Empty;

        public void UpdateProfile(UpdateUserProfileRequest request)
        {
            this.FirstName = string.IsNullOrEmpty(request.FirstName) ? this.FirstName : request.FirstName;
            this.LastName = string.IsNullOrEmpty(request.LastName) ? this.LastName : request.LastName;
            this.PhoneNumber = string.IsNullOrEmpty(request.PhoneNumber) ? this.PhoneNumber : request.PhoneNumber;
            this.Email = string.IsNullOrEmpty(request.Email) ? this.Email : request.Email;
            this.UserName = string.IsNullOrEmpty(request.UserName) ? this.UserName : request.UserName;
            this.UserName = string.IsNullOrEmpty(request.IdentificationCardNumber) ? this.IdentificationCardNumber : request.IdentificationCardNumber;
        }
    }
}
