using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Data.Models
{
    public class PhoneBookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The minimum number of characters required is 2 and a maximum of 50.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed.")]
        public string Name { get; set; }
    }
}
