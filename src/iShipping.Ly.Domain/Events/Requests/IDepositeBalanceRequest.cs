namespace iShipping.Ly.Domain.Events.Requests
{
    public interface IDepositeBalanceRequest
    {
        int WalletId { get; }
        decimal Value { get; }
    }
}
