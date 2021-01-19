using System;
using System.Collections.Generic;
using System.Text;
using DataProviderLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataProviderLayer.DataProviders
{
    public class MemberDataProvider
    {
        ExpertDbContext _expertDbContext;
        public MemberDataProvider(ExpertDbContext expertDbContext)
        {
            _expertDbContext = expertDbContext;
        }

        public void AddMember(Member member)
        {
            _expertDbContext.Members.Add(member);
            _expertDbContext.SaveChanges();
        }
        public void AddFriend(List<Friend> friends)
        {
            _expertDbContext.Friends.AddRange(friends);
            _expertDbContext.SaveChanges();
        }
        public async Task<List<Member>> GetMembers()
        {
            return await _expertDbContext.Members.ToListAsync();
        }
        public async Task<List<Friend>> GetFriends()
        {
            return await _expertDbContext.Friends.ToListAsync();
        }
    }
}
