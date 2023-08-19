namespace iShipping.Ly.Application.Dtos.Identity
{
    public record GetUsersRequest(int CurrentPage = 1, int PageSize = 25);

    public class GetUsersResponse
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IdentificationCardNumber { get; set; } = string.Empty;
    }
}
