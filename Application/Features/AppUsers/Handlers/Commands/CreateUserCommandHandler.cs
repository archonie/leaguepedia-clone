using Application.Contracts.Persistence;
using Application.Features.AppUsers.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AppUsers.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegisterResponse>
{
    private readonly IAppUserRepository _repository;

    public CreateUserCommandHandler(IAppUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<RegisterResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var getUser = await _repository.FindUserByEmail(request.UserDto.Email);
        if (getUser != null)
        {
            return new RegisterResponse(false, "User already registered.");
        }

        var user = new ApplicationUser
        {
            Email = request.UserDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password)
        };
        await _repository.Add(user);
        return new RegisterResponse(true, "User registered succesfully.");

    }
}