using Application.Contracts.Persistence;
using Application.DTOs.Country;
using Application.Exceptions;
using Application.Features.Countries.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Countries.Handlers.Commands;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Unit>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public UpdateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.Get(request.UpdateCountryDto.Id);
        if (country == null)
        {
            throw new NotFoundException(nameof(Country), request.UpdateCountryDto.Id);
        }

        _mapper.Map(request.UpdateCountryDto, country);
        await _countryRepository.Update(country);
        return Unit.Value;
    }
}