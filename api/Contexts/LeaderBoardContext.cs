using c_sherp_project_api.Models;
using Microsoft.EntityFrameworkCore;

namespace c_sherp_project_api.Contexts;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> opt) : base(opt)
    {
        
    }
    public DbSet<LeaderBoard> LeaderBoard { get; set; }
    public DbSet<Game> Games { get; set; }
}