using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataProviderLayer.Entities
{
    public class Friend
    {
        [Key]
        [Column("Id")]
        public string Id { get; set; }

        [Column("MemberId")]
        public string MemberId { get; set; }
        
        [Column("FriendId")]
        public string FriendId { get; set; }
    }
}
