using Microsoft.EntityFrameworkCore;
using Cats_API;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Cat> cats { get; set; }
}

