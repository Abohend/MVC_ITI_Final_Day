namespace ConsoleApp.Model;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    #region Nav - Relation
    public virtual List<Student> Students { get; set; }

    #endregion
}
