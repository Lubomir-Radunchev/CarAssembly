using System.ComponentModel.DataAnnotations;

namespace CarAssembly.ModelDtos.CarDtos
{
    public class CarFromDto
    {
        public int Id { get; set; }
       
        [StringLength(50)]
        public string Brand { get; set; }
      
        [StringLength(100)]
        public string Model { get; set; }
        [StringLength(100)]
        public string Year { get; set; }
        [StringLength(100)]
        public string Kilometers { get; set; }

    }
}
