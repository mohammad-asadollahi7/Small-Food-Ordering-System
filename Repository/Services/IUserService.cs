using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services;

public interface IUserService
{
    public bool IsValid(string username, string password);

}
