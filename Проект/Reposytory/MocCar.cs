using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using Проект.Model;

namespace Проект.Reposytory
{
	public class MocCar : ICar
	{

		private List<Car> _cars;

		public MocCar()
		{
			_cars ??= new List<Car>();

			_cars.Add(new Car { Id = 1, Marka = "Тойота", Model = "Супра", Hp = 350 });
			_cars.Add(new Car { Id = 2, Marka = "Хендай", Model = "Акцент", Hp = 102 });
			_cars.Add(new Car { Id = 3, Marka = "Опель", Model = "Вектра Б", Hp = 100 });
			_cars.Add(new Car { Id = 4, Marka = "Ниссан", Model = "ГТР", Hp = 1000 });
			_cars.Add(new Car { Id = 5, Marka = "Лада", Model = "Приора", Hp = 90 });
			
		}

		public Car UpdateCar(Car carForm)
		{
			var carDB = Get(carForm.Id);
			if (carDB != null)
			{
				_cars.Remove(carDB);
			}
			_cars.Add(carForm);
			return carForm;
		}

		Car ICar.Add(Car car)
		{
			_cars.Add(car);
			return car;
		}

		List<Car> ICar.Delete(int Id)
		{
			var carBD = _cars.Where(u => u.Id == Id).ToList().FirstOrDefault();
			return _cars;
		}

		public Car Get(int Id)
		{
			return _cars.Where(u => u.Id == Id).ToList().FirstOrDefault();
		}

		List<Car> ICar.GetAll()
		{
			return _cars;
		}

		Car ICar.Update(Car car, int Id)
		{
			var carDB = _cars.Where(u => u.Id == Id).ToList().FirstOrDefault();
			if (carDB != null)
			{
				_cars.Remove(carDB);
			}
			_cars.Add(car);
			return car;
		}
	}
}
