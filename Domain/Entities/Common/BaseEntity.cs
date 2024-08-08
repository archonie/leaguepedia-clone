namespace Domain.Entities.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? ModifiedBy { get; set; }

}