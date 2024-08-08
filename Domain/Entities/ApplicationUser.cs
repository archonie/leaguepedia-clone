using Domain.Entities.Common;

namespace Domain.Entities;

public class ApplicationUser : BaseEntity
{   
    public string Email { get; set; }
    public string Password { get; set; }
}