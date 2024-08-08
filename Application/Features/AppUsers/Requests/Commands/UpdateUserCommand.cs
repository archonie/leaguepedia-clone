using Application.DTOs.ApplicationUser;
using Application.Responses;
using MediatR;

namespace Application.Features.AppUsers.Requests.Commands;

public class UpdateUserCommand : IRequest<Unit>
{
    public UpdateUserDto UpdateUserDto { get; set; }
}