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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        public string Name { get; set; }
        
        [Column("Password")]
        public string Password { get; set; }

        [Column("WebsiteUrl")]
        [Required]
        public string WebsiteUrl { get; set; }

        [ForeignKey("Id")]
        public virtual List<Heading> Headings { get; set; }
    }
}
