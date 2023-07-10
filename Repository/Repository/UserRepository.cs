using Data;
using Model;


namespace Repository.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataAccess<User> _dataAccess;

    public UserRepository(DataAccess<User> dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public User? Get(string username, string password)
    {
        return _dataAccess.GetAll().FirstOrDefault(u => u.Username == username 
                                                   && u.Password == password);
    }
}
