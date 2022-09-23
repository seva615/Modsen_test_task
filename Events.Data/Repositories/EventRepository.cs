using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace Events.Data.Repositories
{
    public class EventRepository : GenericRepository<EventEntity>, IEventRepository
    {
    private readonly DataContext _db;

    public EventRepository(DataContext db) : base(db)
    {
        _db = db;
        CollectionWithInclude = db.Events
            .Include(x => x.Address)
            .Include(x => x.Organizers)
                .ThenInclude(x => x.Address)
            .Include(x => x.Plan)
                .ThenInclude(x => x.Speeches)
                    .ThenInclude(x => x.Speaker);



    }
    
        
    }
}