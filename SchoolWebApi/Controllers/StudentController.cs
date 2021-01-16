using System.Threading.Tasks;
using ApplicationCore.Dtos;
using ApplicationCore.Dtos.Student;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IUser;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.JWT;


namespace SchoolWebApi.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class Student : ControllerBase
    {
        
        private readonly IUserRepository<StudentsModel, StudentReadDto> _userRepository;
        private readonly IJwtManager _jwtManager;


        public Student(IUserRepository<StudentsModel,StudentReadDto> userRepository , IJwtManager jwtManager)
        {
            
            _userRepository = userRepository;
            _jwtManager = jwtManager;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("")]
        public async Task<IActionResult> AddStudent(StudentsModel studentsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Invalid Fields"});
            }
            var newStudent = await _userRepository.AddAsync(studentsModel);
            if (newStudent == null) return BadRequest(new {error = "Can't Add The Entity please check inputs"});
            return Ok(newStudent);
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            var student = await _userRepository.SignInAsync(loginModel);
            if (student == null) return NotFound(new {error = "Invalid ssn or password"});
            var token = _jwtManager.Auth(student.Id, student.Role);
            
            return Ok(token);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _userRepository.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("All")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _userRepository.GetAllAsync();
            if (students == null) return NotFound();

            return Ok(students);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _userRepository.DeleteAsync(id);
            if (!student) return NotFound(new {error = "Invalid Id"});
            return Ok();
        }
        
        [HttpPut("")]
        public async Task<IActionResult> UpdateStudent(StudentsModel studentsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {error = "Invalid Fields"});
            }
            var student =await _userRepository.UpdateAsync(studentsModel);
            if (student == null)
            {
                return BadRequest(new {Error = "Cant update this Entity something went wrong"});
            }
            return Ok(student);
        }
    }
}