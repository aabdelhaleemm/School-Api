using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IUser;

namespace ApplicationCore.Dtos.Student
{
    public class StudentReadDto : IUserReadDto
    {
        public int Id { get; set; }

        public int Ssn { get; set; }

        public string Name { get; set; }

        public string BirthDate { get; set; }

        public int Phone { get; set; }
        public bool Bus { get; set; }
        public string Address { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }
        public int ClassNo { get; set; }

        public StudentClassReadDto Class { get; set; }
    }
}