using AutoMapper;
using CarAssembly.Database.Models;
using CarAssembly.ModelDtos.CarDtos;
using CarAssembly.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAssembly.Controllers
{
    public class CarController : Controller
    {
        //dependacy injetion
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        public CarController(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            CarFromDto carFromDto = new CarFromDto();
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
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
