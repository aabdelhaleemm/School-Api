using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;

namespace ApplicationCore.Entities
{
    public class MeetingsModel : ISchoolEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Time { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }

        public classesModel Class { get; set; }
        public TeachersModel Teacher { get; set; }
    }
}