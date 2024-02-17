namespace ConsoleApp.Model;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    #region Nav - Relationship
    public virtual Department Department { get; set; }

    #endregion
   
}
