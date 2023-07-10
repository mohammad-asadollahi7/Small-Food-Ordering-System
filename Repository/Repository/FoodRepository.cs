using Data;
using Model;


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
