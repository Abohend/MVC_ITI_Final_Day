using Microsoft.AspNetCore.Mvc;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers;

public class DepartmentsController : Controller
{
    #region Ctor -- Conn
    
    private readonly CompanyContext _context;
    public DepartmentsController(CompanyContext context)
    {
        //_context = new CompanyContext();
        _context = context;
    }


    #endregion
    #region All Depts
    public IActionResult Index()
    {
        var depts = _context.Departments.ToList();  //>

        return View(depts);
    }
    #endregion
    #region Details
    public IActionResult Details(int id)
    {
        var dept = _context.Departments.Single(d => d.Id == id);

        return View(dept);
    }

    #endregion
    #region Delete
    public IActionResult Delete(int id)
    {
        var deptToDelete = _context.Departments.FirstOrDefault(d => d.Id == id);

        if (deptToDelete is not null)
            _context.Departments.Remove(deptToDelete);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    #endregion
    #region Add
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Department dept)
    {
        //var deptToAdd = new Department
        //{
        //    Name = dept.Name,
        //    Description = dept.Description,
        //};

        _context.Departments.Add(dept);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion
    #region Edit

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var deptToEdit = _context.Departments.Single(d => d.Id == id);
        return View(deptToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Department dept)
    {
        var deptToEdit = _context.Departments.Single(d => d.Id == dept.Id);
        
        deptToEdit.Name = dept.Name;
        deptToEdit.Description = dept.Description;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));

    }




    #endregion
}
