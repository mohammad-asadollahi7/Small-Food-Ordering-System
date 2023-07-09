using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public bool IsValid(string username, string password)
    {
        var user = _userRepository.GetByUsername(username);

        if (user == null)
            return false;
        
        else if (user.Password != password)
            return false;
        
        else
            return true;
    }
}
