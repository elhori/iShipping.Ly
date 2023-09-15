using MediatR;

namespace iShipping.Ly.Application.Dtos.Wallet
{
    public record CreateWalletRequest(decimal Balance = 0m, string CustomerId = null!) : IRequest<bool>;
}
