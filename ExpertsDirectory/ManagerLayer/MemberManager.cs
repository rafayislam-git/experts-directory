using DataProviderLayer.DataProviders;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using DataProviderLayer.Entities;
using Models;
using System.Threading.Tasks;
using System.Linq;

namespace ManagerLayer
{
    public class MemberManager
    {
        private MemberDataProvider _memberDataProvider;
        private WebScrappingHelper _webScrappingHelper;
        public MemberManager(MemberDataProvider memberDataProvider, WebScrappingHelper webScrappingHelper)
        {
            _memberDataProvider = memberDataProvider;
            _webScrappingHelper = webScrappingHelper;
        }

        public void AddMember(MemberDto memberDto)
        {
            string shortUrl = UrlShortner.ShortenUrl(memberDto.Url);

            Member member = new Member()
            {
                Id = Guid.NewGuid().ToString(),
                Name = memberDto.Name,
                WebsiteUrl = memberDto.Url,
                ShortUrl = shortUrl,
                Headings = new List<Heading>()
            };
            var content = _webScrappingHelper.GetTextofHeadingTags(memberDto.Url);

            foreach (var item in content)
            {
                Heading heading = new Heading()
                {
                    Content = item.Content,
                    HeadingType = item.HeadingType,
                    Id = Guid.NewGuid().ToString(),
                    MemberId = member.Id
                };

                member.Headings.Add(heading);
            }

            _memberDataProvider.AddMember(member);

        }
        public void AddFriend(FriendDto friendDto)
        {
            List<Friend> friends = new List<Friend>()
            {
                new Friend()
                {
                FriendId = friendDto.FriendId,
                MemberId = friendDto.MemberId,
                Id = Guid.NewGuid().ToString()
                },
                new Friend()
                {
                    FriendId = friendDto.MemberId,
                    MemberId = friendDto.FriendId,
                    Id = Guid.NewGuid().ToString()
                }
            };


            _memberDataProvider.AddFriend(friends);
        }
        public async Task<List<MembersListDto>> GetMembersList()
        {
            var allMembers = await _memberDataProvider.GetMembers();
            var allFriends = await _memberDataProvider.GetFriends();



            List<MembersListDto> members = new List<MembersListDto>();

            Parallel.ForEach(allMembers, (member =>
            {
                MembersListDto memberDto = new MembersListDto()
                {
                    Name = member.Name,
                    Url = member.ShortUrl,
                    Id = member.Id,
                    Friends = new List<MemberDto>()
                };

                var friends = allFriends.Where(x => x.MemberId == member.Id).ToList();

                Parallel.ForEach(friends, (friend =>
                {
                    var memberFriend = allMembers.Where(x => x.Id == friend.FriendId).FirstOrDefault();

                    if (memberFriend != null)
                    {
                        memberDto.Friends.Add(new MemberDto()
                        {
                            Name = memberFriend.Name,
                            Url = memberFriend.ShortUrl,
                            Id = memberFriend.Id
                        });

                    }

                }));

                members.Add(memberDto);
            }));

            return members;
        }
    }
}
