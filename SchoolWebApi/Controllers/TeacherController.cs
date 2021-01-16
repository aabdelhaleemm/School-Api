using System.Threading.Tasks;
using ApplicationCore.Dtos;
using ApplicationCore.Dtos.Teacher;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IUser;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.JWT;

namespace SchoolWebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IJwtManager _jwtManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository<TeachersModel, TeacherReadDto> _userRepository;

        public TeacherController(IMapper mapper, IJwtManager jwtManager,
            IUserRepository<TeachersModel, TeacherReadDto> userRepository)
        {
            _mapper = mapper;
            _jwtManager = jwtManager;
            _userRepository = userRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTeacher(TeachersModel teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Invalid Fields"});
            }
            var newTeacher = await _userRepository.AddAsync(teacher);
            if (newTeacher == null) return BadRequest(new {error = "Can't Add The Entity please check inputs"});
            return Ok(newTeacher);
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            var teacher = await _userRepository.SignInAsync(loginModel);
            if (teacher == null) return NotFound(new {error = "Invalid ssn or password"});
            var token = _jwtManager.Auth(teacher.Id, teacher.Role);
            
            return Ok(token);
        }
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _userRepository.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }
        [AllowAnonymous]
        [HttpGet("All")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _userRepository.GetAllAsync();
            if (teachers == null) return NotFound();

            return Ok(teachers);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _userRepository.DeleteAsync(id);
            if (!teacher) return NotFound(new {error = "Invalid Id"});
            return Ok();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateTeacher(TeachersModel teacherModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Invalid Fields"});
            }
            var teacher =await _userRepository.UpdateAsync(teacherModel);
            if (teacher == null)
            {
                return BadRequest(new {Error = "Cant update this Entity something went wrong"});
            }
            return Ok(teacher);
        }
        
    }
}