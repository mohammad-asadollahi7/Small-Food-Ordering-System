using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository;

public class FoodRepository : IFoodRepository
{
    private DataAccess<Food> _dataAccess;

    public FoodRepository(DataAccess<Food> dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public List<Food> GetAll()
    {
        return _dataAccess.GetAll();
    }
}
