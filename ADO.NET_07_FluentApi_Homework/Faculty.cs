namespace ADO.NET_07_FluentApi_Homework;

public class Faculty
{
    public int FacultyId { get; set; }  

    public string? Name { get; set; }

    public List<Student> Students { get; set; } = [];
}
