using iShipping.Ly.Domain.Events;
using iShipping.Ly.Domain.Events.Requests;
using iShipping.Ly.Domain.Extensions;
using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class Wallet : Aggregate<Wallet>
    {
        private Wallet() { }

        public Wallet(WalletModel model)
        {
            Balance = model.Balance;
            CustomerId = model.CustomerId;
        }

        public decimal Balance { get; private set; }

        public string CustomerId { get; private set; } = string.Empty;

        #region Deposite
        public void Deposite(IDepositeBalanceRequest request)
        {
            var @event = request.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void Apply(BalanceDepositedEvent @event)
        {
            Balance += @event.Data.Value;
        }
        #endregion

        #region Withdraw
        public void Withdraw(IWithdrawBalanceRequest request)
        {
            if (Balance < 0 || Balance < request.Value)
                return;

            var @event = request.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void Apply(BalanceWithdrawEvent @event)
        {
            Balance -= @event.Data.Value;
        }
        #endregion

        #region Pay
        public void Pay(IPayRequest request)
        {
            if (Balance < 0 || Balance < request.Value)
                return;

            var @event = request.ToEvent(sequence: Sequence + 1);

            ApplyChange(@event);
        }

        public void Apply(BalancePaidEvent @event)
        {
            Balance -= @event.Data.Value;
        }
        #endregion
    }
}
