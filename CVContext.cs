using cv_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cv_backend;

public class CVContext : DbContext
{
    public CVContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }

}