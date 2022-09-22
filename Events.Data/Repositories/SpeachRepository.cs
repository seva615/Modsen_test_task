using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Data.Repositories
{
    public class SpeachRepository : GenericRepository<SpeachEntity>, ISpeachRepository
    {
        private readonly DataContext _db;
        
        public SpeachRepository(DataContext db) : base(db)
        {
            _db = db;
            CollectionWithInclude = db.Speaches
                .Include(x => x.Speaker);
        }
    }
}