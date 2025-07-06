using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Session")]
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int EId { get; set; } 

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        public int SId { get; set; } 

        public string Desc { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public string Url { get; set; }
    }
}
