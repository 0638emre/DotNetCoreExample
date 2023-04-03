using Bussiness.Abstract;
using Bussiness.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetController : ControllerBase
    {
        private readonly IMeetService _meetService;

        public MeetController(IMeetService meetService)
        {
            _meetService = meetService;
        }


        [HttpGet("GetMeetById")]
        public async Task<IActionResult> GetMeetById([FromQuery] Guid meetId)
        {
            var data = await _meetService.GetMeetByIdAsync(meetId);
            return Ok(data);
        }

        [HttpPost("CreateMeetAsync")]
        public async Task<IActionResult> CreateMeetAsync([FromBody] CreateMeetDTO createMeet)
        {
            var data = await _meetService.CreateMeetAsync(createMeet);
            return Ok(data);
        }

        [HttpPost("AddUserToMeetAsync")]
        public async Task<IActionResult> AddUserToMeetAsync([FromBody] AddUserToMeetDTO createMeet)
        {
            var data = await _meetService.AddUserToMeetAsync(createMeet);
            return Ok(data);
        }

        [HttpDelete("RemoveMeetAsync")]
        public async Task<IActionResult> RemoveMeetAsync([FromQuery] Guid meetId)
        {
            var data = await _meetService.RemoveMeetAsync(meetId);
            return Ok(data);
        }

        [HttpDelete("UpdateMeetAsync")]
        public async Task<IActionResult> UpdateMeetAsync([FromBody] UpdateMeetDTO updateMeet)
        {
            var data = await _meetService.UpdateMeetAsync(updateMeet);
            return Ok(data);
        }

        [HttpPost("AddDocumentToMeetAsync")]
        public async Task<IActionResult> AddDocumentToMeetAsync([FromBody] AddDocumentToMeetDTO addDocumentToMeet)
        {
            var data = await _meetService.AddDocumentToMeetAsync(addDocumentToMeet);
            return Ok(data);
        }
    }
}
