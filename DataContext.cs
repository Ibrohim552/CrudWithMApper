


using Microsoft.EntityFrameworkCore;

public class DataContex:DbContext
{
    public DbSet<Person> Person { get; set; }
    public DataContex(DbContextOptions<DataContex> options) : base(options)
    {
    }
}