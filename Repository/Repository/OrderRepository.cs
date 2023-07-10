using Data;
using Model;


namespace Repository.Repository;

public class OrderRepository : IOrderRepository
{
    private DataAccess<Order> _dataAccess;

    public OrderRepository(DataAccess<Order> dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public List<Order> GetAll()
    {
        return _dataAccess.GetAll();
    }

    public bool Update(Order UpdatedOrder)
    {
        var oldOrderIndex = _dataAccess.data.FindIndex
                             (o => o.UserId == UpdatedOrder.UserId);
        _dataAccess.data[oldOrderIndex] = UpdatedOrder;
        _dataAccess.SaveChanges();
        return true;
    }
    public bool Create(Order newOrder)
    {
        if (_dataAccess.data == null)
            _dataAccess.data = new List<Order>();
        
        _dataAccess.data.Add(newOrder);
        _dataAccess.SaveChanges();
        return true;
    }

}
