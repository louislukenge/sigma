using CandidateManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CandidateManagementAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasKey(c => c.Email);
        }

    }
}
