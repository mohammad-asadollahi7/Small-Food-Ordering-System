using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository;

public class OrderRepository : IOrderRepository
{
    private DataAccess<Order> _dataAccess;

    public OrderRepository(DataAccess<Order> dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public bool Create(Order newOrder)
    {
        _dataAccess.GetAll();
        if (_dataAccess.data == null)
            _dataAccess.data = new List<Order>();
        
        _dataAccess.data.Add(newOrder);
        _dataAccess.SaveChanges();
        return true;
    }

}
