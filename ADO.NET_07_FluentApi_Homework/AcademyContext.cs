using Microsoft.EntityFrameworkCore;


namespace ADO.NET_07_FluentApi_Homework;

public class AcademyContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Faculty> Faculties { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public AcademyContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Academy;Integrated Security=SSPI;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Group

        modelBuilder.Entity<Group>()
            .Property(z => z.GroupId).HasColumnName("Id")
            .IsRequired().ValueGeneratedOnAdd();

        modelBuilder.Entity<Group>().HasKey(z => z.GroupId);

        modelBuilder.Entity<Group>().Property(z => z.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(10);

        modelBuilder.Entity<Group>().HasIndex(z => z.Name).IsUnique();

        modelBuilder.Entity<Group>().ToTable(z => z.HasCheckConstraint("CK_Group_Name", "Name != ''"));

        modelBuilder.Entity<Group>().Property(z => z.Rating).IsRequired();

        modelBuilder.Entity<Group>().ToTable(z => z.HasCheckConstraint("CK_Group_Rating", "Rating >= 0 AND Rating <= 5"));


        modelBuilder.Entity<Group>().Property(z => z.Year).IsRequired();

        modelBuilder.Entity<Group>().ToTable(z => z.HasCheckConstraint("CK_Group_Year", "Year >= 1 AND Year <= 5"));

        modelBuilder.Entity<Group>()
            .HasOne(z => z.Teacher).WithMany(x => x.Groups)
            .HasForeignKey(z => z.TeacherId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Groups");


        //Department

        modelBuilder.Entity<Department>().Property(z => z.DepartmentId).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();

        modelBuilder.Entity<Department>().HasKey(z => z.DepartmentId);

        modelBuilder.Entity<Department>().Property(z => z.Financing)
            .HasColumnType("money").IsRequired().HasDefaultValue(0);

        modelBuilder.Entity<Department>().ToTable(z => z.HasCheckConstraint("CK_Department_Financing", "Financing >= 0"));

        modelBuilder.Entity<Department>().Property(z => z.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Department>().HasIndex(z => z.Name).IsUnique();

        modelBuilder.Entity<Department>().ToTable(z => z.HasCheckConstraint("CK_Department_Name", "Name!=''"));


        //Faculty

        modelBuilder.Entity<Faculty>().Property(z => z.FacultyId).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();

        modelBuilder.Entity<Faculty>().HasKey(z => z.FacultyId);


        modelBuilder.Entity<Faculty>().Property(z => z.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Faculty>().HasIndex(z => z.Name).IsUnique();

        modelBuilder.Entity<Faculty>().ToTable(z => z.HasCheckConstraint("CK_Faculty_Name", "Name!=''"));


        //Teachers

        modelBuilder.Entity<Teacher>().Property(z => z.TeacherId).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();

        modelBuilder.Entity<Teacher>().HasKey(z => z.TeacherId);


        modelBuilder.Entity<Teacher>().Property(z => z.EmploymentDate).HasColumnType("Date").IsRequired();

        modelBuilder.Entity<Teacher>().ToTable(z => z.HasCheckConstraint("CK_Teacher_EmploymentDate", "EmploymentDate>='19900101'"));

        modelBuilder.Entity<Teacher>().Property(z => z.FirstName).HasColumnName("Name").HasColumnType("nvarchar(max)").IsRequired();

        modelBuilder.Entity<Teacher>().ToTable(z => z.HasCheckConstraint("CK_Teacher_Name", "Name != ''"));

        modelBuilder.Entity<Teacher>().Property(z => z.Premium).HasColumnType("money").IsRequired().HasDefaultValue(0);

        modelBuilder.Entity<Teacher>()
            .ToTable(z => z.HasCheckConstraint("CK_Teacher_Premium", "Premium >= 0"));


        modelBuilder.Entity<Teacher>().Property(z => z.Salary).HasColumnType("money").IsRequired();

        modelBuilder.Entity<Teacher>()
            .ToTable(z => z.HasCheckConstraint("CK_Teacher_Salary", "Salary > 0"));

        modelBuilder.Entity<Teacher>().Property(z => z.LastName).HasColumnName("Surname").HasColumnType("nvarchar(max)").IsRequired();

        modelBuilder.Entity<Teacher>().ToTable(z => z.HasCheckConstraint("CK_Teacher_Surname", "Surname != ''"));

        modelBuilder.Entity<Teacher>().HasOne(z => z.Department).WithMany(x => x.Teachers).HasForeignKey(z => z.TeacherId).HasConstraintName("FK_Teachers").OnDelete(DeleteBehavior.Cascade);


        //Students

        modelBuilder.Entity<Student>().Property(z => z.StudentId).HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>().HasKey(z => z.StudentId);

        modelBuilder.Entity<Student>().Property(z => z.LastName).HasColumnName("Surname").HasColumnType("nvarchar(max)").IsRequired();

        modelBuilder.Entity<Student>().ToTable(z => z.HasCheckConstraint("CK_Student_Surname", "Surname != ''"));

        modelBuilder.Entity<Student>().Property(z => z.FirstName).HasColumnName("Name").HasColumnType("nvarchar(max)").IsRequired();

        modelBuilder.Entity<Student>().ToTable(z => z.HasCheckConstraint("CK_Student_Name", "Name != ''"));

        modelBuilder.Entity<Student>().HasOne(z => z.Group)
            .WithMany(x => x.Students).HasForeignKey(z => z.GroupId)
            .HasConstraintName("FK_Students_Group").OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>().HasOne(z => z.Faculty)
            .WithMany(x => x.Students).HasForeignKey(z => z.FacultyId).HasConstraintName("FK_Students_Faculty").OnDelete(DeleteBehavior.Cascade);

    }

}
