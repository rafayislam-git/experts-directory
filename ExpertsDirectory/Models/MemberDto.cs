using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MemberDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
    }

    public class MembersListDto : MemberDto
    {
        public List<MemberDto> Friends { get; set; }
    }
}
