using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace commenergy.Models.Models
{
    public class Ratings
    {
         [Key]
        public int RatingId { get; set; }
        
        public int ArticleId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public float Rating { get; set; }        
    }
    }

