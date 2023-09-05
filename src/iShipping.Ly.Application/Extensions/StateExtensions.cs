using iShipping.Ly.Application.Dtos.States;
using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Application.Extensions
{
    public static class StateExtensions
    {
        public static StateModel ToModel(this CreateStateRequest request)
        {
            return new StateModel(Id: 0, Name: request.Name);
        }

        public static StateModel ToModel(this UpdateStateRequest request)
        {
            return new StateModel(Id: request.Id, Name: request.Name);
        }

        public static GetStatesResponse ToResponse(this State state)
        {
            return new GetStatesResponse
            {
                Id = state.Id,
                Name = state.Name
            };
        }
    }
}
