using Application.DTOs.ApplicationUser;
using Application.Responses;
using MediatR;

namespace Application.Features.AppUsers.Requests.Commands;

public class CreateUserCommand : IRequest<RegisterResponse>
{
    public CreateUserDto UserDto { get; set; }
}