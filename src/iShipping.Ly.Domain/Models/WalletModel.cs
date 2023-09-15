namespace iShipping.Ly.Domain.Models
{
    public record WalletModel(
        int Id,
        decimal Balance = 0m,
        string CustomerId = null!);
}
