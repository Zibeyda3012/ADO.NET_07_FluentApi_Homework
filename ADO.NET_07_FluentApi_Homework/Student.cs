namespace ADO.NET_07_FluentApi_Homework;

public class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    //foreign keys

    public int FacultyId { get; set; }  

    public int GroupId { get; set; }    


    //navigation property
    public Faculty? Faculty { get; set; }

    public Group? Group { get; set; }
   
}
