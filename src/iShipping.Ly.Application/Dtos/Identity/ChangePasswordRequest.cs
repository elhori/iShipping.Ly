namespace iShipping.Ly.Application.Dtos.Identity
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
