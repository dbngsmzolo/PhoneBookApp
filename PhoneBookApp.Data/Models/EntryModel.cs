using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Data.Models
{
    public class EntryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The minimum number of characters required is 2 and a maximum of 50.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Phone number.")]
        [StringLength(10, ErrorMessage = "Phone number must contain 10 digits.")]
        [RegularExpression(@"^((?:\+27|27)|0)(\d{2})(?:-| )?(\d{3})(?:-| )?(\d{4})$", ErrorMessage = "Invalid Phone number.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "PhoneBookId is required.")]
        public int PhoneBookId { get; set; }
    }
}
