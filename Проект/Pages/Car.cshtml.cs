using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Проект.Model;
using Проект.Reposytory;

namespace Проект.Pages
{
    public class CarModel : PageModel
    {
		public CarModel(ICar CarRepository)
		{
			_carRepository = CarRepository;
		}
		private ICar _carRepository;
		public Car? Car { get; set; }
		public IActionResult OnGet(int id = 1)
		{
			Car = _carRepository.Get(id);
			if (Car == null) return NotFound(); 
			return Page(); 
		}
	}
}
