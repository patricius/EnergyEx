using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace commenergy.Models
{
 public class Comment
    {
        public int ID { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [StringLength(75)]
        [Required]
        public string Author {get;set;}

        [Required]
        public string Body { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [Url]
        public string URL { get; set; }

        public int ArticleID { get; set; }
    }
}

