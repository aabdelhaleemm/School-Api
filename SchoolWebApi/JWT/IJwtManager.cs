namespace SchoolWebApi.JWT
{
    public interface IJwtManager
    {
        public string Auth(int id, string role);
    }
}