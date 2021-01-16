using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IUser;

namespace ApplicationCore.Entities
{
    public class TeachersModel : IUserEntity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Ssn { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public int Phone { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }

        public IEnumerable<MeetingsModel> Meetings { get; set; }
        public IEnumerable<ObjectsModel> Objects { get; set; }
        public IEnumerable<HomeWorksModel> HomeWorks { get; set; }
    }
}