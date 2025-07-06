using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("ParticipantEventDetails")]
    public class ParticipantEventDetails
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string ParticipantEmailId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [RegularExpression("Yes|No", ErrorMessage = "must be Yes or No")]
        public string IsAttended { get; set; }
    }
}
