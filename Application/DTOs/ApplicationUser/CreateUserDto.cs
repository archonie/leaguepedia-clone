using System.ComponentModel.DataAnnotations;
using Application.DTOs.Common;

namespace Application.DTOs.ApplicationUser;

public record CreateUserDto
{
        [Required, EmailAddress] public string? Email { get; set; } = string.Empty;
        [Required] public string? Password { get; set; } = string.Empty;
        [Required, Compare(nameof(Password))] public string? ConfirmPassword { get; set; } = string.Empty;

}