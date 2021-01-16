namespace ApplicationCore.Dtos.Object
{
    public class ObjectHomeWorksReadDto
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public string DueTime { get; set; }
        public int TeacherId { get; set; }
        public int ClassNo { get; set; }
        public int ObjectId { get; set; }
    }
}