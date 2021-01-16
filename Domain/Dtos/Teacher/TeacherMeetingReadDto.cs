namespace ApplicationCore.Dtos.Teacher
{
    public class TeacherMeetingReadDto
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
    }
}