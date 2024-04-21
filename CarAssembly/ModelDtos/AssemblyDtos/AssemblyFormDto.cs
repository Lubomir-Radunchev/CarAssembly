using CarAssembly.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace CarAssembly.ModelDtos.Assembly
{
    public class AssemblyFormDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Condtion { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public byte[]? Picture { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public List<Category> Categories = new List<Category>();
        public List<string> Condtions = new List<string>();
        public List<Car> Cars = new List<Car>();
    }
}
