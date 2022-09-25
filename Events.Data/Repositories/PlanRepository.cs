using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Data.Repositories
{
    public class PlanRepository : GenericRepository<PlanEntity>, IPlanRepository
    {
        private readonly DataContext _db;
        
        public PlanRepository(DataContext db) : base(db)
        {
            _db = db;
            CollectionWithInclude = db.Plans
             .Include(x => x.Speeches)
             .ThenInclude(x => x.Speaker);

        }
        
    }
}