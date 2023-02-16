using System.ComponentModel.DataAnnotations;

namespace dotnet.Models.Entities;

public class User
{
   [Key] 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
    public DateTime DateTime { get; set; }
}
