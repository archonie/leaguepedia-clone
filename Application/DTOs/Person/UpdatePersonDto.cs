using Application.DTOs.Common;

namespace Application.DTOs.Person;

public record UpdatePersonDto : BaseDto
{
    public string Name { get; set; }
    public string? NameInLatin { get; set; }
    public string Nickname { get; set; }
    public DateTime Birthday { get; set; }
    public int Age { get; set; }    
    public int CountryId { get; set; }
    public int ResidencyId { get; set; }
    public string Role { get; set; }
    public int TeamId { get; set; }
    public bool IsRetired { get; set; }
}