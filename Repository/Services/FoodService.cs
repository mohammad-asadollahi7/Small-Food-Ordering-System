using Model;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services;

public class FoodService : IFoodService
{
    private IFoodRepository _restaurantRepository;

    public FoodService(IFoodRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }
    public List<Food> GetAll()
    {
        return _restaurantRepository.GetAll();
    }
}
