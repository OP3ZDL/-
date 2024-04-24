using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Проект.Model;
using Проект.Reposytory;

namespace Проект.Pages
{
    public class editCarModel : PageModel
    {
        public editCarModel(ICar CarReposytory)
        {
            _CarReposytory = CarReposytory;
        }

        private ICar _CarReposytory;
        public Car Car { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = _CarReposytory.Get(id);
            Car ??= new();
            Console.WriteLine($"Received Car ID: {Car.Id}, Marka: {Car.Marka}, Model: {Car.Model}, HP: {Car.Hp}");
            return Page();
        }

        public IActionResult OnPost(Car CarForm)
        {

            Car = _CarReposytory.Update(CarForm);

            if (Car == null) return NotFound();

            return RedirectToPage("Cars");
        }
    }
}
