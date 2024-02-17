using Проект.Model;

namespace Проект.Reposytory
{
	public interface ICar
	{
		public Car Add(Car car);

		public Car Update(Car car, int Id);

		public List<Car> Delete(int car);

		public Car Get(int Id);

		public List<Car> GetAll();
		Car UpdateCar(Car carForm);
	}
}
