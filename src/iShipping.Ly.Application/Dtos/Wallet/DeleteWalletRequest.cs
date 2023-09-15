using MediatR;

namespace iShipping.Ly.Application.Dtos.Wallet
{
    public record DeleteWalletRequest(int Id) : IRequest<bool>;
}
