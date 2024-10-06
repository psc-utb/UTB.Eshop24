using System.ComponentModel.DataAnnotations;

namespace UTB.Eshop.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
        public string? RepeatedPassword { get; set; }
    }
}

