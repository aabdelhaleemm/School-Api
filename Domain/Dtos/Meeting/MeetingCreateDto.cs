namespace ApplicationCore.Dtos.Meeting
{
    public class MeetingCreateDto
    {
        public string Time { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
    }
}