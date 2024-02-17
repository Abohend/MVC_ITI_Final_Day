using ConsoleApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Context;

public class SchoolContext : DbContext
{
    //> DBsets 
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }  
    public SchoolContext() { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=SchoolDB;Trusted_Connection=True;Encrypt=False")
        .UseLazyLoadingProxies();
}
