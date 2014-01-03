using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace commenergy.Models
{
    public class Article
    {
        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string Author { get; set; }
        public int Id { get; set; }
        public int? UserId { get; set; }

        [StringLength(75)]
       
        public string Key { get; set; }
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedOn { get; set; }
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? UpdatedOn { get; set; }

        [StringLength(75)]
        [Required]
        public string Title { get; set; }

        [StringLength(250)]
        [Required]
        public string MetaDescription { get; set; }

        [Required]
        public string Body { get; set; }

        public Article()
        {
            Comments = new List<Comment>();
        }

        //[EmailAddress]
        //[Required]
        //public string Email { get; set; }

        //[Required]
        //public string IpAddress { get; set; }

        //[DataAnnotationsExtensions.Url]
        //public string URL { get; set; }


        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// A link to the article
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string URLTo
        {
            get
            {
                return
                    System.Web.VirtualPathUtility.ToAbsolute(string.Format(
                        CultureInfo.InvariantCulture,
                        "~/articles/{0}/{1}/{2}/{3}",
                        this.CreatedOn.Year.ToString("0000", CultureInfo.InvariantCulture),
                        this.CreatedOn.Month.ToString("00", CultureInfo.InvariantCulture),
                        this.CreatedOn.Day.ToString("00", CultureInfo.InvariantCulture),
                        this.Key));
            }
        }
    }
}