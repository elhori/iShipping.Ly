using iShipping.Ly.Domain.Events.Requests;
using MediatR;
using System.Text.Json.Serialization;

namespace iShipping.Ly.Application.Dtos.Wallet
{
    public record PayRequest(int WalletId, decimal Value, [property: JsonIgnore] string Description)
        : IRequest<string>, IPayRequest;
}
