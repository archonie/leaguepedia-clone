using Domain.Entities.Common;

namespace Domain.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; }
    public string Abrv { get; set; }
    public int LeagueId { get; set; }
    public virtual League League { get; set; }
    public virtual List<Person> Players { get; set; }
    public int FoundedCountryId { get; set; }
    public virtual Country FoundedCountry { get; set; }
    public int CurrentCountryId { get; set; }
    public virtual Country CurrentCountry { get; set; }
    public int RegionId { get; set; }
    public virtual Region Region { get; set; }
    
}