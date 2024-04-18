using CarAssembly.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAssembly.Controllers
{
    public class CategoryController : Controller
    {
        //dependacy injetion
        private readonly ApplicationDbContext data;

        public CategoryController(ApplicationDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (String.IsNullOrEmpty(category.Name))
            {
                // message: try again 
                TempData["error"] = "Try Again";
                return View();
            }

            this.data.Categories.Add(category);
            this.data.SaveChanges();
            
            return View();
        }

        
    }
}
