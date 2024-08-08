using MediatR;

namespace Application.Features.AppUsers.Requests.Commands;

public class DeleteUserCommand : IRequest<Unit>
{
    public int Id { get; set; }   
}