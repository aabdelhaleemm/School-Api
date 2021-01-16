
using System.Threading.Tasks;
using ApplicationCore.Dtos.Meeting;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.ISchool;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace SchoolWebApi.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly ISchoolRepository<MeetingsModel, MeetingReadDto> _schoolRepository;
        
        public MeetingController( ISchoolRepository<MeetingsModel,MeetingReadDto> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddMeeting(MeetingsModel MeetingsModel)
        {
            var newMeeting =await _schoolRepository.AddAsync(MeetingsModel);
            if (newMeeting == null)
            {
                return BadRequest(new {error = "Invalid Inputs"});
            }

            return Ok(newMeeting);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMeetingById(int id)
        {
            var entity = await _schoolRepository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllMeetings()
        {
            var entity = await _schoolRepository.GetAllAsync();
            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(int id)
        {
            var entity = await _schoolRepository.DeleteAsync(id);
            if (!entity) return NotFound(new {error = "Invalid Id"});
            return Ok();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateMeeting(MeetingsModel meetingsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Invalid Fields"});
            }
            var entity =await _schoolRepository.UpdateAsync(meetingsModel);
            if (entity == null)
            {
                return BadRequest(new {Error = "Cant update this Entity something went wrong"});
            }
            return Ok(entity);
        }
    }
}