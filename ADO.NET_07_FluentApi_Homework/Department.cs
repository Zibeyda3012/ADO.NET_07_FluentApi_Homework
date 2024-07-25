namespace ADO.NET_07_FluentApi_Homework;

public class Department
{
    public int DepartmentId { get; set; }

    public string? Name { get; set; }

    public decimal Financing {  get; set; }

    public List<Teacher> Teachers { get; set; } = [];
}
