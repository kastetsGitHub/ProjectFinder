using Microsoft.EntityFrameworkCore;

namespace Service.FindGitHubAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    //public required DbSet<Finder> Finder { get; set; }
}
