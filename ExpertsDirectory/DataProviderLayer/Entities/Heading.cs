using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataProviderLayer.Entities
{
    public class Heading
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("HeadingType")]
        [Required]
        public string HeadingType { get; set; }

        [Column("Content")]
        public string Content { get; set; }

        [Column("MemberId")]
        [Required]
        public int MemberId { get; set; }
    }
}
