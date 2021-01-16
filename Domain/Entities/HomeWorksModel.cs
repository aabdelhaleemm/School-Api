using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;

namespace ApplicationCore.Entities
{
    public class HomeWorksModel : ISchoolEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Info { get; set; }

        public string DueTime { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
        public int ObjectId { get; set; }

        public TeachersModel Teacher { get; set; }
        public classesModel Class { get; set; }
        public ObjectsModel Object { get; set; }
    }
}