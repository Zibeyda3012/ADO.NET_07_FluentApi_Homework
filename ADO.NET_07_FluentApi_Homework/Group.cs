namespace ADO.NET_07_FluentApi_Homework;

public class Group
{
    public int GroupId { get; set; }

    public string? Name { get; set; }

    public int Rating { get; set; }

    public int Year { get; set; }

    public List<Student> Students { get; set; } = [];

    //foreign key
    public int TeacherId { get; set; }

    //navigation property

    public Teacher? Teacher { get; set; }    

}
