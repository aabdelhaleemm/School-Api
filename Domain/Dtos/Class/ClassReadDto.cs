using System.Collections.Generic;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;

namespace ApplicationCore.Dtos.Class
{
    public class ClassReadDto : ISchoolReadDto
    {
        public int Id { get; set; }
        public int ClassNo { get; set; }
        public int TotalStudent { get; set; }
        public double Price { get; set; }

        public IEnumerable<ClassMeetingReadDto> Meetings { get; set; }
        public IEnumerable<ClassObjectReadDto> Objects { get; set; }
        public IEnumerable<ClassHomeWorksReadDto> HomeWorks { get; set; }
        public IEnumerable<ClassStudentReadDto> Students { get; set; }
    }
}