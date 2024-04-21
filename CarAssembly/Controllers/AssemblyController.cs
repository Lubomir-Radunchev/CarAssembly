using AutoMapper;
using CarAssembly.Database.Models;
using CarAssembly.ModelDtos.Assembly;
using CarAssembly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarAssembly.Controllers
{
    public class AssemblyController : Controller
    {
        //dependacy injetion
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;
        public AssemblyController(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult AddAssembly()
        {

            AssemblyFormDto assembly = new AssemblyFormDto();
            assembly.Cars = this.data.Cars.ToList();
            assembly.Categories = this.data.Categories.ToList();
            foreach (var cond in Enum.GetValues(typeof(Condtion)))
            {
                assembly.Condtions.Add(cond.ToString());
            }

            return View(assembly);
        }
        [HttpPost]
        public IActionResult AddAssembly(AssemblyFormDto assembly, List<IFormFile> Picture)
        {

            if (String.IsNullOrEmpty(assembly.Name))
            {
                // message: try again 
                TempData["error"] = "Try Again";
                assembly.Categories = this.data.Categories.ToList();

                foreach (var cond in Enum.GetValues(typeof(Condtion)))
                {
                    assembly.Condtions.Add(cond.ToString());
                }

                return View();
            }

            var assemblyEntity = mapper.Map<Assembly>(assembly);

            byte[] photo = new byte[8000];
            foreach (var item in Picture)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        item.CopyToAsync(stream);
                        photo = stream.ToArray();
                    }
                }
            }

            assemblyEntity.Picture = photo;

            this.data.Assemblies.Add(assemblyEntity);
            this.data.SaveChanges();

            return RedirectToAction("Add", "Assembly");
        }

        //[HttpPost]
        //public async Task<IActionResult> SavePhoto(IFormFile Picture, AssemblyFormDto fromDto)
        //{
        //    if (Picture != null && Picture.Length > 0)
        //    {
        //        byte[] photoBytes;
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            await Picture.CopyToAsync(memoryStream);
        //            photoBytes = memoryStream.ToArray();

        //        }
        //    }

        //    return RedirectToAction("Add Picture"); // Redirect to home page after photo is saved
        //}

    }
}

