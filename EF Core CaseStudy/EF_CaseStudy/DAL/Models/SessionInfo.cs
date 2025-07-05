using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
        [Table("SessionInfo")]
        public class SessionInfo
        {
            [Key]
            public int SessionId { get; set; }

            [Required]
            [ForeignKey("EventDetails")]
            public int EventId { get; set; }
            public EventDetails EventDetails { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 1)]
            public string SessionTitle { get; set; }

        public string Description { get; set; }

            [Required]
            public DateTime SessionStart { get; set; }

            [Required]
            public DateTime SessionEnd { get; set; }

            public string SessionUrl { get; set; }
        }
}
