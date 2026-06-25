using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Models.Auth
{
    public class ResetPasswordModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}