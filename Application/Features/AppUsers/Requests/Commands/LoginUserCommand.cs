using Application.DTOs.ApplicationUser;
using Application.Responses;
using MediatR;

namespace Application.Features.AppUsers.Requests.Commands;

public class LoginUserCommand : IRequest<LoginResponse>
{
    public LoginDto LoginDto { get; set; }
}