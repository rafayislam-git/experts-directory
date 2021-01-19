using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagerLayer;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ExpertsDirectory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private MemberManager _memberManager;
        public MembersController(MemberManager memberManager)
        {
            _memberManager = memberManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                ResponseDto response = new ResponseDto()
                {
                    Message = "Success",
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = await _memberManager.GetMembersList()
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                ResponseDto response = new ResponseDto()
                {
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

                return BadRequest(response);
            }
        }

       
        [HttpPost]
        public IActionResult Post([FromBody] MemberDto member)
        {
            try
            {
                _memberManager.AddMember(member);

                ResponseDto response = new ResponseDto()
                {
                    Message = "Success",
                    StatusCode = System.Net.HttpStatusCode.OK
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                ResponseDto response = new ResponseDto()
                {
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

                return BadRequest(response);
            }

        }
        [HttpPost("Friend")]
        public IActionResult AddFriend([FromBody] FriendDto friend)
        {
            try
            {
                _memberManager.AddFriend(friend);

                ResponseDto response = new ResponseDto()
                {
                    Message = "Success",
                    StatusCode = System.Net.HttpStatusCode.OK
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                ResponseDto response = new ResponseDto()
                {
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };

                return BadRequest(response);
            }

        }

    }
}
