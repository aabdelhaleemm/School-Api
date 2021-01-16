using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IUser;

namespace ApplicationCore.Entities
{
    public class StudentsModel : IUserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Ssn { get; set; }
        [Required]

        public string Name { get; set; }

        public string BirthDate { get; set; }

        public int Phone { get; set; }
        public bool Bus { get; set; }
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
        [Required] 
        public string Role { get; set; } = "Student";
        public int ClassNo { get; set; }

        public classesModel Class { get; set; }
    }
}