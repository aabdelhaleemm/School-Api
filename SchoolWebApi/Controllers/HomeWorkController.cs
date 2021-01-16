using System.Threading.Tasks;
using ApplicationCore.Dtos.HomeWork;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.ISchool;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace SchoolWebApi.Controllers
{
    [Authorize(Roles = "Teacher , Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorkController : ControllerBase
    {
        private readonly ISchoolRepository<HomeWorksModel, HomeWorkReadDto> _schoolRepository;
        
        public HomeWorkController( ISchoolRepository<HomeWorksModel,HomeWorkReadDto> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddMeeting(HomeWorksModel homeWorksModel)
        {
            var newHomeWork =await _schoolRepository.AddAsync(homeWorksModel);
            if (newHomeWork == null)
            {
                return BadRequest(new {error = "Invalid Inputs"});
            }

            return Ok(newHomeWork);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHomeWorkById(int id)
        {
            var entity = await _schoolRepository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllHomeWorks()
        {
            var entity = await _schoolRepository.GetAllAsync();
            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeWork(int id)
        {
            var entity = await _schoolRepository.DeleteAsync(id);
            if (!entity) return NotFound(new {error = "Invalid Id"});
            return Ok();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateHomeWork(HomeWorksModel homeWorksModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Invalid Fields"});
            }
            var entity =await _schoolRepository.UpdateAsync(homeWorksModel);
            if (entity == null)
            {
                return BadRequest(new {Error = "Cant update this Entity something went wrong"});
            }
            return Ok(entity);
        }
    }
}