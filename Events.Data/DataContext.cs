using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            modelBuilder.Entity<EventEntity>().HasOne(e => e.Address).WithOne(e=> e.Event).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EventEntity>().HasOne(e => e.Plan).WithOne(e => e.Event).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OrganizerEntity>().HasMany(e => e.Events).WithOne(e => e.Organizer).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PlanEntity>().HasMany(e => e.Speeches).WithOne(e => e.Plan).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SpeakerEntity>().HasMany(e => e.Speeches).WithOne(e => e.Speaker).OnDelete(DeleteBehavior.Cascade);
        }
    }
}