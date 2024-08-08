using Application.Contracts.Persistence;
using Application.DTOs.ApplicationUser;
using Application.Features.AppUsers.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.AppUsers.Handlers.Queries;

public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<AppUserDto>>
{
    private readonly IAppUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserListRequestHandler(IAppUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<List<AppUserDto>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.Get();
        return _mapper.Map<List<AppUserDto>>(users);
    }
}