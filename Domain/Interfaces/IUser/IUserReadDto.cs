namespace ApplicationCore.Interfaces.IUser
{
    public interface IUserReadDto
    {
        public int Id { get; set; }
        public int Ssn { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}