using System.ComponentModel.DataAnnotations;

namespace BookModelvalidation.Models
{
    public class Book
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Isbn cannot be left blank, must be unique in the list")]
        public int Isbn { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "BookName cannot be left blank")]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Length should be between 1-20 char.")]
        public string BookName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "AuthorName cannot be left blank")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Length should be between 1-50 char.")]
        public string AuthorName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Must not be advance date")]
        public DateTime PublishedDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Value must be valid web url")]
        public string BookUrl { get; set; }
    }
}
