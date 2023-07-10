using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository;

public interface IOrderRepository
{
    public bool Create(Order newOrder);
}
