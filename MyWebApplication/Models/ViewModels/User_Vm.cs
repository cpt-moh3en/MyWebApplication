using System;
namespace MyWebApplication.Models.ViewModels;

public class User_Vm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string ImageName { get; set; }
    public IFormFile ImageFile { get; set; }
    public string DateTime { get; set; }
    public DateTime Date_Time { get; set; }
}
