using System.ComponentModel.DataAnnotations;
using Application.DTOs.Common;  

namespace Application.DTOs.ApplicationUser;

public record UpdateUserDto : BaseDto
{
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}