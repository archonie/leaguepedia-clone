using Domain.Entities.Common;

namespace Domain.Entities;

public class League : BaseEntity
{
    public string Name { get; set; }
    public string Abrv { get; set; }
    public int CountryId { get; set; }
    public virtual Country Country { get; set; }
    public virtual  Region Region { get; set; }
    public int RegionId { get; set; }
    public string Organizer { get; set; }
    public string EventType { get; set; }
    public string? EventCountry { get; set; }
    public string? EventCity { get; set; }
    public double? RewardAmount { get; set; }
    public virtual List<Team> Teams { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
}