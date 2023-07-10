using Model;
using Repository.Repository;

namespace Repository.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User? CheckUser(string username, string password)
    {
        return _userRepository.Get(username, password);
    }
}
