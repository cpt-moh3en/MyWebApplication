using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models.Entities;

public class MyClass
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public byte? Age { get; set; }
}
