using System.Threading.Tasks;
using ApplicationCore.Dtos.Object;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace SchoolWebApi.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        
        private readonly ISchoolRepository<ObjectsModel, ObjectReadDto> _schoolRepository;


        public ObjectController( ISchoolRepository<ObjectsModel,ObjectReadDto> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddObject(ObjectsModel objectsModel)
        {
            var newObject =await _schoolRepository.AddAsync(objectsModel);
            if (newObject == null)
            {
                return BadRequest(new {error = "Invalid Inputs"});
            }

            return Ok(newObject);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetObjectById(int id)
        {
            var entity = await _schoolRepository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllObjects()
        {
            var entity = await _schoolRepository.GetAllAsync();
            if (entity == null) return NotFound();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObject(int id)
        {
            var entity = await _schoolRepository.DeleteAsync(id);
            if (!entity) return NotFound(new {error = "Invalid Id"});
            return Ok();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateObject(ObjectsModel objectsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Invalid Fields"});
            }
            var entity =await _schoolRepository.UpdateAsync(objectsModel);
            if (entity == null)
            {
                return BadRequest(new {Error = "Cant update this Entity something went wrong"});
            }
            return Ok(entity);
        }
    }
}