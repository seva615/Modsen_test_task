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
        
        public DbSet<AddressEntity> Addresses { get; set; }
        
        public DbSet<EventEntity> Events { get; set; }
        
        public DbSet<OrganizerEntity> Organizers { get; set; }
        
        public DbSet<PlanEntity> Plans { get; set; }
        
        public DbSet<SpeechEntity> Speeches { get; set; }
        
        public DbSet<SpeakerEntity> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntity>().HasOne(e => e.Address).WithOne(e => e.Event);
            modelBuilder.Entity<EventEntity>().HasMany(e => e.Organizers).WithMany(e => e.Events);
            modelBuilder.Entity<EventEntity>().HasOne(e => e.Plan).WithOne(e => e.Event);
            modelBuilder.Entity<OrganizerEntity>().HasOne(e => e.Address).WithOne(e => e.Organizer);
            modelBuilder.Entity<PlanEntity>().HasMany(e => e.Speeches).WithOne(e => e.Plan);
            modelBuilder.Entity<SpeechEntity>().HasOne(e => e.Speaker).WithMany(e => e.Speeches);
        }
    }
}