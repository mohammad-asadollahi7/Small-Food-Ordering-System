using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private Order _newOrder;

    public OrderService(IOrderRepository orderRepository, Order newOrder)
    {
        _orderRepository = orderRepository;
        _newOrder = newOrder;
    }

    public bool Add(Food food, int userId)
    {
        _newOrder.Id = Guid.NewGuid();
        _newOrder.UserId = userId;
        if (_newOrder.Foods == null)
        {
            _newOrder.Foods = new List<Food>();
        }
        _newOrder.Foods.Add(food);
        _newOrder.TotalPrice += food.Price;

        return _orderRepository.Create(_newOrder);
    }
}
