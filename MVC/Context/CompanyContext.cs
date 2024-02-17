using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MVC.Models;

namespace MVC.Context;

public class CompanyContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    //public CompanyContext() { }
    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=.;Database=!CompanyDB;Trusted_Connection=True;Encrypt=False");
}
