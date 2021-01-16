using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;

namespace ApplicationCore.Entities
{
    public class classesModel : ISchoolEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClassNo { get; set; }
        public int TotalStudent { get; set; }
        public double Price { get; set; }

        public IEnumerable<MeetingsModel> Meetings { get; set; }
        public IEnumerable<ObjectsModel> Objects { get; set; }
        public IEnumerable<HomeWorksModel> HomeWorks { get; set; }
        public IEnumerable<StudentsModel> Students { get; set; }
    }
}