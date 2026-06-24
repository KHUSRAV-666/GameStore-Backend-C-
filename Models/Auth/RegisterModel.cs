using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Models.Auth
{
  public class RegisterModel
  {
    [Required]
    public string Username { get; set; } = string.Empty;
    // [Required]
    // [EmailAddress]
    // public string Email { get; set; } = string.Empty;
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
  }
}