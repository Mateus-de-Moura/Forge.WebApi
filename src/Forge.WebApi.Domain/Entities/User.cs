using System.ComponentModel.DataAnnotations;

namespace Forge.WebApi.Domain.Entities
{
    public class User : BaseEntity
    {   
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string? Surname { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [Required]
        public string? PasswordSalt { get; set; }

        [Required]
        public string? UserName { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpirationTime { get; set; }    
    }
}
