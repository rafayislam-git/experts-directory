using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataProviderLayer.Entities
{
    public class Member
    {
        [Column("Id")]
        [Key]
        [Required]
        public string Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }
        
        [Column("Password")]
        public string Password { get; set; }

        [Column("WebsiteUrl")]
        [Required]
        public string WebsiteUrl { get; set; }
        
        [Column("ShortUrl")]
        [Required]
        public string ShortUrl { get; set; }

        public virtual List<Heading> Headings { get; set; }
    }
}
