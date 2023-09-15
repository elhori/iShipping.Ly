namespace iShipping.Ly.Domain.Events.Requests
{
    public interface IWithdrawBalanceRequest
    {
        int WalletId { get; }
        decimal Value { get; }
    }
}
