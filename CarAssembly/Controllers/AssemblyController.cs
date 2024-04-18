using CarAssembly.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAssembly.Controllers
{
    public class AssemblyController : Controller
    {
        //dependacy injetion
        private readonly ApplicationDbContext data;
        public AssemblyController(ApplicationDbContext data)
        {
            this.data = data;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Assembly assembly)
        {
            if (String.IsNullOrEmpty(assembly.Name))
            {
                // message: try again 
                TempData["error"] = "Try Again";
                return View();
            }

            this.data.Assemblies.Add(assembly);
            this.data.SaveChanges();

            return View();
        }
    }
}
