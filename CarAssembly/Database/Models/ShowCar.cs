using CarAssembly.ModelDtos.Assembly;
using CarAssembly.ModelDtos.CarDtos;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CarAssembly.Database.Models
{
    public class ShowCar
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public readonly AssemblyFormDto AssemblyForShowCar;
        public readonly CarFromDto CarForShowCar;
        public ShowCar(AssemblyFormDto assembly, CarFromDto car)
        {
            this.AssemblyForShowCar = assembly;
            this.CarForShowCar = car;


        }
        

        public void ShowCarFromAssembly(AssemblyFormDto assembly)
        {
            this.AssemblyForShowCar.Condtion = assembly.Condtion;
            this.AssemblyForShowCar.Description = assembly.Description;
            this.AssemblyForShowCar.Category = assembly.Category;
            this.AssemblyForShowCar.Picture = assembly.Picture;
            
        }
        public void ShowCarFromCar(CarFromDto car)
        {
            this.CarForShowCar.Brand = car.Brand;   
            this.CarForShowCar.Model = car.Model;
            this.CarForShowCar.Year = car.Year;
            this.CarForShowCar.Kilometers = car.Kilometers;
           
        }
        public ShowCar()
        {
            CarForShowCar = new CarFromDto();
            AssemblyForShowCar = new AssemblyFormDto();

        }


    }
}
