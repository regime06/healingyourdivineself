using System.ComponentModel.DataAnnotations;

namespace HealingDivineSelf.Models
{
    public class UserWorkshop
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? Email { get; set; }

        public string? AreaCode { get; set; } = "+63";

        public string? PhoneNumber { get; set; }
    }
}
