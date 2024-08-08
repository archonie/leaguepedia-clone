using Application.Contracts.Persistence;
using Application.DTOs.ApplicationUser;
using Application.Features.AppUsers.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.AppUsers.Handlers.Queries;

public class GetUserRequestHandler : IRequestHandler<GetUserRequest, AppUserDto>
{
    private readonly IAppUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserRequestHandler(IAppUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<AppUserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _repository.Get(request.Id);
        return _mapper.Map<AppUserDto>(user);
    }
}