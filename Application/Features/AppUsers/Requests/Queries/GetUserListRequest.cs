using Application.DTOs.ApplicationUser;
using MediatR;

namespace Application.Features.AppUsers.Requests.Queries;

public class GetUserListRequest : IRequest<List<AppUserDto>>
{
    
}