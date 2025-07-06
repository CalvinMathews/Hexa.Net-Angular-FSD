using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("SpeakersDetails")]
    public class SpeakersDetails
    {
        [Key]
        [Required]
        public int SpeakerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string SpeakerName { get; set; }
    }
}
