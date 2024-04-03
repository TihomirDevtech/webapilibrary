using System.ComponentModel.DataAnnotations;
using WebLibraryAPI.Models.Domain;

namespace WebLibraryAPI.Dtos.Auth;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public string? Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; } = string.Empty;

    [Required]
    [MinLength(7)]
    public string? Password { get; set; } = string.Empty;
}
