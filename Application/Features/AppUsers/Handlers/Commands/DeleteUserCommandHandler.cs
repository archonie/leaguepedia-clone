using System.Globalization;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.AppUsers.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AppUsers.Handlers.Commands;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IAppUserRepository _repository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IAppUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.Get(request.Id);
        if (user == null)
        {
            throw new NotFoundException(nameof(ApplicationUser), request.Id);
        }
        await _repository.Delete(user);
        return Unit.Value;
    }
}