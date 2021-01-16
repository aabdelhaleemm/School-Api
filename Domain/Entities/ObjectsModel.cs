using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;

namespace ApplicationCore.Entities
{
    public class ObjectsModel : ISchoolEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
        public TeachersModel Teacher { get; set; }
        public classesModel Class { get; set; }
        public IEnumerable<HomeWorksModel> HomeWorks { get; set; }
    }
}