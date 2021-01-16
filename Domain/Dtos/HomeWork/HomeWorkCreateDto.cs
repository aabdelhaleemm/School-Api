namespace ApplicationCore.Dtos.HomeWork
{
    public class HomeWorkCreateDto
    {
        public string Info { get; set; }
        public string DueTime { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
        public int ObjectId { get; set; }
    }
}