namespace ADO.NET_07_FluentApi_Homework;

public class Teacher
{

    public int TeacherId { get; set; }  

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly EmploymentDate { get; set; }

    public decimal Salary { get; set; }

    public decimal Premium { get; set; }

    public List<Group> Groups { get; set; } = [];


    //foreigh key
    public int DepartmentId {  get; set; }

    //navigation property
    public Department? Department { get; set; }


}
