using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Проект.Model;
using Проект.Reposytory;

namespace Проект.Pages
{
	public class CarsModel : PageModel
	{
		public CarsModel(ICar carRepository)
		{
			_carRepository = carRepository;
		}
		private ICar _carRepository;
		public List<Car> Cars { get; set; }
		public IActionResult OnGet()
		{
			Cars = _carRepository.GetAll();
			return Page();
		}

		public IActionResult OnPostDelete(int id)
		{
			_carRepository.Delete(id);
			return RedirectToPage();
		}
	}
}