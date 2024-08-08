using Domain.Entities.Common;

namespace Domain.Entities;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public string? NameInLatin { get; set; }
    public string Nickname { get; set; }
    public DateTime Birthday { get; set; }
    public int Age { get; set; }
    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
    public int ResidencyId { get; set; }
    public virtual Region Region { get; set; }
    public string Role { get; set; }
    public int TeamId { get; set; }
    public virtual Team Team { get; set; }
    public bool IsRetired { get; set; }
}