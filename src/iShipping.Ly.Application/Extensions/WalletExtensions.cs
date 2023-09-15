using iShipping.Ly.Application.Dtos.Wallet;
using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Application.Extensions
{
    public static class WalletExtensions
    {
        public static WalletModel ToModel(this CreateWalletRequest request)
        {
            return new WalletModel(Id: 0, Balance: request.Balance, CustomerId: request.CustomerId);
        }
    }
}
