using Domain.Entities.Common;

namespace Domain.Entities;

public class Region : BaseEntity
{
    public string Name { get; set; }
    public string Abrv { get; set; }
    public List<Country> Countries { get; set; }
}