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
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(CarFromDto car)
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
            var carEntity = mapper.Map<Car>(car);
            // assemblyEntity.Picture = photo;

            this.data.Cars.Add(carEntity);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}
