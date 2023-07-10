using Model;
using Repository.Repository;



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

    public bool CreateOrUpdate(Food food, int userId)
    {
        var orders = _orderRepository.GetAll();
        if (orders != null)
        {
            var order = orders.FirstOrDefault(o => o.UserId == userId);
            if (order != null)
            {
                order.Foods.Add(food);
                order.TotalPrice += food.Price;
                return _orderRepository.Update(order);
            }
            else
            {
                var newOrder = CreateNewOrder(food, userId);
                return _orderRepository.Create(newOrder);
            }
        }
        else
        {
            var newOrder = CreateNewOrder(food, userId);
            return _orderRepository.Create(newOrder);
        }
    }


    private Order CreateNewOrder(Food food, int userId)
    {
        _newOrder.Id = Guid.NewGuid();
        _newOrder.UserId = userId;
        var foods = new List<Food>();
        foods.Add(food);
        _newOrder.Foods = foods;
        _newOrder.TotalPrice = food.Price;
        return _newOrder;
    }
}
