using Microsoft.EntityFrameworkCore;
using TalentVN.ApplicationCore.Entities;

namespace TalentVN.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<SchoolProfile> SchoolProfiles { get; set; }
        public DbSet<Specialized> Specializeds { get; set; }
        public DbSet<SRank> SRanks { get; set; }
        public DbSet<SRankItem> SRankItems { get; set; }
    }
}
