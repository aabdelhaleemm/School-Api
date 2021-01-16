using System.Collections.Generic;
using ApplicationCore.Dtos.Class;
using ApplicationCore.Dtos.Teacher;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;

namespace ApplicationCore.Dtos.Object
{
    public class ObjectReadDto : ISchoolReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
        
        
        
    }
}