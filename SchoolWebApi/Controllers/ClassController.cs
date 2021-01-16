using System.Threading.Tasks;
using ApplicationCore.Dtos.Class;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.ISchool;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace SchoolWebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ISchoolRepository<classesModel, ClassReadDto> _schoolRepository;
        
        public ClassController( ISchoolRepository<classesModel,ClassReadDto> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddClass(classesModel classesModel)
        {
            var newClass =await _schoolRepository.AddAsync(classesModel);
            if (newClass == null)
            {
                return BadRequest(new {error = "Invalid Inputs"});
            }

            return Ok(newClass);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var entity = await _schoolRepository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllClassess()
        {
            var entity = await _schoolRepository.GetAllAsync();
            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var entity = await _schoolRepository.DeleteAsync(id);
            if (!entity) return NotFound(new {error = "Invalid Id"});
            return Ok();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateClass(classesModel classesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Invalid Fields"});
            }
            var entity =await _schoolRepository.UpdateAsync(classesModel);
            if (entity == null)
            {
                return BadRequest(new {Error = "Cant update this Entity something went wrong"});
            }
            return Ok(entity);
        }
    }
}