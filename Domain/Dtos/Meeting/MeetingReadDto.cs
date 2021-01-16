using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;

namespace ApplicationCore.Dtos.Meeting
{
    public class MeetingReadDto : ISchoolReadDto
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
        public MeetingClassReadDto Class { get; set; }
        public MeetingTeacherReadDto Teacher { get; set; }
    }
}