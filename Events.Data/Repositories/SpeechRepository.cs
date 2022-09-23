using Events.Data.DataInterfaces;
using Events.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Events.Data.Repositories
{
    public class SpeechRepository : GenericRepository<SpeechEntity>, ISpeechRepository
    {
        private readonly DataContext _db;
        
        public SpeechRepository(DataContext db) : base(db)
        {
            _db = db;
            CollectionWithInclude = db.Speeches
                .Include(x => x.Speaker);
        }
    }
}