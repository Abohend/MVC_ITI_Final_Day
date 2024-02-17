using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Context;
using MVC.Models;

namespace MVC.Controllers;

public class EmployeesController : Controller
{
    #region Ctor -- Conn
    private readonly CompanyContext _context;
    public EmployeesController(CompanyContext context)
    {
        _context = context;
        //_context = new CompanyContext();
    }

    #endregion


    #region All Emps
    public IActionResult Index()
    {
        var emps = _context.Employees.ToList();
        return View(emps);
    }

    #endregion

    #region Details

    public IActionResult Details(int id)
    {
        var emp = _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);   
        return View(emp);
    }

    #endregion

    #region Delete/Remove
    public IActionResult Delete(int id)
    {
        var empToDelete = _context.Employees.FirstOrDefault(e => e.Id == id) ?? new();

        _context.Employees.Remove(empToDelete);

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Add

    [HttpGet]
    public IActionResult Add()
    {
        GetDeptListItems();

        return View();
    }

   

    [HttpPost]
    public IActionResult Add(Employee emp)
    {
        if (!ModelState.IsValid)
        {
            GetDeptListItems();

            return View();
        }


        var empToAdd = new Employee
        {
            Name = emp.Name,
            Age = emp.Age,
            Phone = emp.Phone,
            DeptId = emp.DeptId,
        };

        _context.Employees.Add(emp);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }


    #endregion

    #region Edit

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var emp = _context.Employees.Find(id);

        GetDeptListItems();

        return View(emp);
    }

    [HttpPost]
    public IActionResult Edit(Employee emp)
    {
        var empToEdit = _context.Employees.Find(emp.Id);

        if (!ModelState.IsValid)
        {
            GetDeptListItems();

            return View();
        }


        empToEdit!.Name = emp.Name;
        empToEdit.Phone = emp.Phone;
        empToEdit.Age = emp.Age;
        empToEdit.DeptId = emp.DeptId;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));

    }


    #endregion

    #region Helpers

    private void GetDeptListItems()
    {
        var deptListItem = _context.Departments
            .Select(d => new SelectListItem(d.Name, d.Id.ToString()));

        ViewBag.depts = deptListItem;
    }

    #endregion
}
