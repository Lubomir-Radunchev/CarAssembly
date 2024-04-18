using System.ComponentModel.DataAnnotations;

namespace CarAssembly.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Assembly> Assemblies = new List<Assembly>();
    }
}
