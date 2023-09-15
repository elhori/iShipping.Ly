namespace iShipping.Ly.Domain.Events.Requests
{
    public interface IPayRequest
    {
        int WalletId { get; }
        decimal Value { get; }

        string Description { get; }
    }
}
