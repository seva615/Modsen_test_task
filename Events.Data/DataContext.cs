using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
        
            : base(options) 
        {
            
        }
        
        public DbSet<EventEntity> Events { get; set; }
        
        public DbSet<OrganizerEntity> Organizers { get; set; }
        
        public DbSet<SpeakerEntity> Speakers { get; set; }
        
        public DbSet<AddressEntity> Addresses { get; set; }

        public DbSet<PlanEntity> Plans { get; set; }
        
        public DbSet<m2mOrganaizerEventEntity> OrgaganaizersEnvents { get; set; }
        
        public DbSet<m2mSpeakerPlanEntity> SpeakersPlans { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}