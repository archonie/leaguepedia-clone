using Application.DTOs.ApplicationUser;
using MediatR;

namespace Application.Features.AppUsers.Requests.Queries;

public class GetUserRequest : IRequest<AppUserDto>
{
    public int Id { get; set; }
}