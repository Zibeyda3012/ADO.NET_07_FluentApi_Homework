using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ADO.NET_07_FluentApi_Homework;

public class AcademyContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Faculty> Faculties { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public AcademyContext()
    {
        
    }

}
