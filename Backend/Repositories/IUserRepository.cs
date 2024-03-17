namespace Backend.Repositories
{
    public interface IUserRepository
    {
        bool IsUnique(string email);
    }
}
