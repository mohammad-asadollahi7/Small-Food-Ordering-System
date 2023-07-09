using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataAccess<User> _dataAccess;

    public UserRepository(DataAccess<User> dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public User? GetByUsername(string username)
    {
        return _dataAccess.GetAll().FirstOrDefault(u => u.Username == username);
    }
}
