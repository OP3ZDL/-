using Проект.Model;

namespace Проект.Reposytory
{
    public class SqlCar : ICar
    {
        private readonly AppDbContext _appDbContext;

        public SqlCar(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Car Add(Car car)
        {
            _appDbContext.Cars.Add(car);
            _appDbContext.SaveChanges();
            return car;

        }

        public Car Update(Car UpCar)
        {
            if (UpCar.Id == 0)
            {
                _appDbContext.Cars.Add(UpCar);
            }
            else
            {
                _appDbContext.Cars.Update(UpCar);
            }
            _appDbContext.SaveChanges();
            return UpCar;
        }

        public Car Delete(int id)
        {
            var car = Get(id);
            _appDbContext.Remove(car);
            _appDbContext.SaveChanges();
            return car;
        }

        public Car Get(int Id)
        {
            return _appDbContext.Cars.Where(u => u.Id == Id).ToList().FirstOrDefault();
        }

        public List<Car> GetAll()
        {
            return _appDbContext.Cars.ToList();
        }
    }
}
