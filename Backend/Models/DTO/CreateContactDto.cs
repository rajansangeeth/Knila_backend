using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public class CreateContactDto
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int PostalCode { get; set; }
    }
}
