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
        
        public DbSet<SpeachEntity> Speaches { get; set; }
        
        public DbSet<SpeakerEntity> Speakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventEntity>().HasOne(e => e.Address).WithOne(e => e.Event);
            modelBuilder.Entity<EventEntity>().HasMany(e => e.Organaizers).WithMany(e => e.Events);
            modelBuilder.Entity<EventEntity>().HasOne(e => e.Plan).WithOne(e => e.Event);
            modelBuilder.Entity<OrganizerEntity>().HasOne(e => e.Address).WithOne(e => e.Organaizer);
            modelBuilder.Entity<PlanEntity>().HasMany(e => e.Speaches).WithOne(e => e.Plan);
            modelBuilder.Entity<SpeachEntity>().HasOne(e => e.Speaker).WithMany(e => e.Speaches);
        }
    }
}