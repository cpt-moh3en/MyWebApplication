using dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Models.Context;

public class DotNetContext : DbContext
{
    public DotNetContext(DbContextOptions<DotNetContext> options) : base(options){}
    public DbSet<User> Tbl_User{ get; set; }
    public DbSet<Admin> Tbl_Admin{ get; set; }
    public DbSet<MyClass> Tbl_MyClass{ get; set; }
}