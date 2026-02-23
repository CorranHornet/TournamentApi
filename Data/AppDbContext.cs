using Microsoft.EntityFrameworkCore;
using TournamentApi.Models;

namespace TournamentApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Tournament> Tournaments => Set<Tournament>();
    }
}
