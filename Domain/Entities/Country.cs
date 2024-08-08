using Domain.Entities.Common;

namespace Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; }
    public int RegionId { get; set; }
    public virtual Region Region { get; set; }
    public virtual List<League> Leagues { get; set; }
    public virtual List<Team> NativeTeams { get; set; }
    public virtual List<Team> OperatingTeams { get; set; }
    public virtual List<Person> Persons { get; set; }
    public string Abrv { get; set; }
}