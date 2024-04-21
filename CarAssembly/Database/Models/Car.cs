using System.ComponentModel.DataAnnotations;

namespace CarAssembly.Database.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        [Required]
        [StringLength(100)]
        public string Model { get; set; }
        [Required]
        [StringLength(100)]
        public string Year { get; set; }
        [Required]
        [StringLength(100)]
        public string Kilometers { get; set; }

        public List<Assembly> Assemblies = new List<Assembly>();
    }
}
