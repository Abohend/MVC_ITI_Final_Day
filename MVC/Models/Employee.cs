using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models;

public partial class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*")]
    [MaxLength(20), MinLength(3, ErrorMessage = "Name must be greater than 2 letters.")]
    public string Name { get; set; } = string.Empty;

    [Range(20, 60, ErrorMessage = "{0} Must be between {1} and {2}")]
    public int Age { get; set; }

    [Required(ErrorMessage = "*")]
    [RegularExpression("01[0125][0-9]{8}", ErrorMessage = "Enter Valid Number.")]
    public string Phone { get; set; } = string.Empty;

    #region Navigation - Relations
    
    [ForeignKey(nameof(Department))]
    [DisplayName("Department")]
    public int? DeptId { get; set; }
    public Department? Department { get; set; } 

    #endregion
}

