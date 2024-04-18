using CarAssembly.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAssembly.Controllers
{
    public class CarController : Controller
    {
        //dependacy injetion
        private readonly ApplicationDbContext data;
        public CarController(ApplicationDbContext data)
        {
            this.data = data;
        }
        [HttpGet]
            public IActionResult Add()
            {
                return View();
            }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (String.IsNullOrEmpty(car.Model))
            {
                // message: try again 
                TempData["error"] = "Try Again";
                return View();
            }
            if (String.IsNullOrEmpty(car.Brand))
            {
                // message: try again 
                TempData["error"] = "Try Again";
                return View();                                      
            }

            this.data.Cars.Add(car);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}
