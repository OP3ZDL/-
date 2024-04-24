using Проект.Model;

namespace Проект.Reposytory
{
	public interface ICar
	{
		public Car Add(Car car);

		public Car Update(Car UpCar);

		public Car Delete(int Id);

		public Car Get(int Id);

		public List<Car> GetAll();
		
	}
}
