using System.Collections.Generic;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IUser;

namespace ApplicationCore.Dtos.Teacher
{
    public class TeacherReadDto : IUserReadDto
    {
        public int Id { get; set; }
        public int Ssn { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public IEnumerable<TeacherMeetingReadDto> Meetings { get; set; }
        public IEnumerable<TeacherObjectReadDto> Objects { get; set; }
        public IEnumerable<TeacherHomeWorkReadDto> HomeWorks { get; set; }
    }
}