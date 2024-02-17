using ConsoleApp.Context;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp;


public class Program
{
    static void Main(string[] args)
    {
        using SchoolContext context = new();

        context.Database.ExecuteSql($"DBCC CHECKIDENT('Employees', RESEED, 0)");



        //> 1) Normal Loading --> no Load-- > Null

        var students = context.Students.Select(s => s).ToList();

        foreach (var student in students)
            Console.WriteLine($"{student.Name}, {student.Department.Name}");


        //> 2) Eager Loading --> Include

        //var students = context.Students.Include(s => s.Department).Select(s => s).ToList();

        //foreach (var student in students)
        //    Console.WriteLine($"{student.Name}, {student.Department.Name}");


        //> 3) Explicit Loading --> N + 1 trip --> Load()

        //var students = context.Students.Select(s => s).ToList();
        //foreach (var student in students)
        //{
        //    if (student.Department == null)
        //        context.Entry(student).Reference(s => s.Department).Load();

        //    Console.WriteLine($"{student.Name}, {student.Department!.Name}");
        //}

        //> 4) Lazy Loading -- Virtual 

        //var students = context.Students.Select(s => s).ToList();

        //foreach (var student in students)
        //    Console.WriteLine($"{student.Name}, {student.Department.Name}");


        //> 5) Select Loading

        //var students = context.Students.Select(s => new {Name = s.Name, Department = s.Department}).ToList();

        //foreach (var student in students)
        //    Console.WriteLine($"{student.Name}, {student.Department.Name}");



        //int[] arr = { 1,2,3,4};

        //var data = arr?.Length ?? new int;


        string str = null;

        Console.WriteLine(str ?? "Na");


    }
}