using ApplicationCore.Dtos.Class;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;

namespace ApplicationCore.Dtos.HomeWork
{
    public class HomeWorkReadDto : ISchoolReadDto
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public string DueTime { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
        public int ObjectId { get; set; }
        public HomeWorkTeacherReadDtop Teacher { get; set; }
        public ClassReadDto Class { get; set; }
        public HomeWorkObjectReadDto Object { get; set; }
    }
}