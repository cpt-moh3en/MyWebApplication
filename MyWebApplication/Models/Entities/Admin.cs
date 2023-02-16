using System.ComponentModel.DataAnnotations;

namespace dotnet.Models.Entities;

public class Admin
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Image { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime DateTime { get; set; }
    public bool Status { get; set; }

}
