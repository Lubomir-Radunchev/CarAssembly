using System.ComponentModel.DataAnnotations;
namespace CarAssembly.Models;

public class Assembly
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    public Condtion Condtion { get; set; }

    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    public byte[] Photo { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Car Car { get; set; }
}


public enum Condtion
{
    broken, bad, none, good, newest
}
