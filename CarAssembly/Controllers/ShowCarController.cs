using AutoMapper;
using CarAssembly.Database.Models;
using CarAssembly.ModelDtos.CarDtos;
using CarAssembly.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAssembly.Controllers
{
    public class ShowCarController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;



        public ShowCarController(ApplicationDbContext data, IMapper mapper)
        {
            this.mapper = mapper;
            this.data = data;
        }
        [HttpGet]
        public IActionResult ShowResults(ShowCar cars = null)
        {

            //if (cars != null && cars.CarForShowCar != null)
            //{
            //    //cars.CarForShowCar.Model.ToList();
            //    //cars.CarForShowCar.Kilometers.ToList();
            //    //cars.CarForShowCar.Year.ToList();
            //    //cars.CarForShowCar.Brand.ToList();
            //}
            //else if (cars != null &&cars.AssemblyForShowCar != null)
            //{
            //    //cars.AssemblyForShowCar.Picture.ToArray();
            //    //cars.AssemblyForShowCar.Condtion.ToList();
            //    //cars.AssemblyForShowCar.Description.ToList();
            //    //cars.AssemblyForShowCar.Name.ToList();
            //}

            this.data.ShowCars.Add(cars);
            return View("ShowCarResult", cars);
        }


    }
}
