﻿using MediatR;

namespace iShipping.Ly.Application.Dtos.States
{
    public record UpdateStateRequest(int Id, string Name, int CityId) : IRequest<GetStatesResponse>;
}
